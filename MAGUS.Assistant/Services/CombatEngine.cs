using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.ViewModels;
using MAGUS.Bestiary;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.GameSystem.Turn;
using MAGUS.Interfaces;
using Mtf.LanguageService;

namespace MAGUS.Assistant.Services;

internal sealed class CombatEngine
{
    public static async Task ProcessAssignmentTurnAsync(AssignmentViewModel assignment, int round, ICombatRollService rollService)
    {
        var turn = new TurnData { Round = round };
        var initiatives = await EncounterHelpers.GetInitiativesAsync(assignment, turn, rollService).ConfigureAwait(false);
        //turn.Initiatives.AddRange(initiatives);

        foreach (var initiative in initiatives)
        {
            await ProcessInitiativeAsync(turn, initiative, assignment, rollService).ConfigureAwait(false);
        }

        TickActiveEffects(turn, assignment.Character);
        foreach (var enemy in assignment.Enemies)
        {
            TickActiveEffects(turn, enemy);
        }

        if (turn.Initiatives.Count != 0)
        {
            // Ensure collection modifications that affect UI are performed on the main thread
            await MainThread.InvokeOnMainThreadAsync(() => assignment.AddTurn(turn)).ConfigureAwait(false);
        }

        // A psi surge or spell empowerment only banks its bonus for the round it was invoked in.
        assignment.Character.ClearPsiSurge();
        assignment.Character.ClearSpellPower();

        // Temporary combat modifiers (direction bonuses, psi effects like PsiPush's defense
        // penalty) are only ever meant to last the round they were applied in. They're normally
        // cleared per-attacker at the start of each of that attacker's own initiatives, but a
        // modifier applied to a target rather than an attacker (e.g. PsiPush hitting an enemy)
        // would otherwise linger indefinitely, so clear everyone's explicitly at round end too.
        assignment.Character.RemoveTemporaryModifiers();
        foreach (var enemy in assignment.Enemies)
        {
            enemy.RemoveTemporaryModifiers();
        }
    }

    private static void TickActiveEffects(TurnData turn, Attacker attacker)
    {
        if (attacker.ActiveEffects.Count == 0 || attacker.IsDead)
        {
            return;
        }

        foreach (var effect in attacker.ActiveEffects.ToList())
        {
            var wasDead = attacker.IsDead;
            var wasConscious = attacker.IsConscious;

            var tickDamage = Math.Max(0, effect.GetTickDamage());
            if (effect.IsHpDamage)
            {
                attacker.ActualHealthPoints -= tickDamage;
            }
            else
            {
                attacker.ActualPainTolerancePoints -= tickDamage;
            }

            effect.RemainingRounds--;
            if (effect.RemainingRounds <= 0)
            {
                attacker.ActiveEffects.Remove(effect);
            }

            turn.Initiatives.Add(new InitiativeEntry
            {
                Kind = InitiativeEntryKind.EffectTick,
                Attacker = new CombatantRef(attacker),
                Target = new CombatantRef(attacker),
                SelectedAttack = null,
                BaseInitiative = 0,
                RolledValue = 0
            });

            AddStateChanges(turn, attacker, wasDead, wasConscious);

            if (attacker.IsDead)
            {
                break;
            }
        }
    }

    private static async Task ProcessInitiativeAsync(TurnData turn, InitiativeEntry initiative, AssignmentViewModel assignment, ICombatRollService rollService)
    {
        Attacker attacker = initiative.Attacker.Source;
        Attacker target = initiative.Target.Source;
        
        if (attacker.IsDead || target.IsDead || !attacker.IsConscious)
        {
            return;
        }

        initiative.Attacker.RemoveTemporaryModifiers();
        var attackDirection = attacker.AttackDirection;

        if (attackDirection == AttackDirection.Behind)
        {
            initiative.Attacker.AddTemporaryModifier(new AttackFromBehind());
        }
        else if (attackDirection == AttackDirection.HalfBehind)
        {
            initiative.Attacker.AddTemporaryModifier(new AttackFromHalfBehind());
        }

        if (initiative.SelectedAttack == null)
        {
            //EncounterHelpers.GetInitiativesInternalAsync decreases the distance
            return;
        }

        var targetWasDead = target.IsDead;
        var targetWasConscious = target.IsConscious;

        var attackerWasDead = attacker.IsDead;
        var attackerWasConscious = attacker.IsConscious;

        var name = attacker.GetName();
        var hitLocationTitle = $"{name} - {Lng.Elem("Hit location")}";
        if (!target.IsConscious)
        {
            // Automatic damage
            //var baseDamage = await initiative.SelectedAttack.GetDamageAsync(rollService).ConfigureAwait(false);
            var baseDamage = initiative.SelectedAttack.GetDamage();
            var finalDamage = Math.Max(0, baseDamage - (target.Armor?.ArmorClass ?? 0));
            target.ActualHealthPoints -= finalDamage;

            initiative.AttackOrAimResolution = await ForcedResolution.CreateAsync(initiative, finalDamage, attackDirection, rollService, hitLocationTitle).ConfigureAwait(false);

            turn.Initiatives.Add(initiative);
            AddStateChanges(turn, attacker, attackerWasDead, attackerWasConscious);
            AddStateChanges(turn, target, targetWasDead, targetWasConscious);
        }
        else
        {
            if (initiative.SelectedAttack is RangedAttack rangedAttack)
            {
                var targetDistance = assignment.GetDistanceInMeters(target);
                initiative.AttackOrAimResolution = await AimResolution.CreateAsync(
                    initiative,
                    targetDistance,
                    MovementType.Predictable,
                    WeatherCondition.Clear,
                    rollService,
                    $"{name} - {Lng.Elem("Aim")}",
                    rangedAttack,
                    attackDirection,
                    hitLocationTitle,
                    rollService is ManualCombatRollService).ConfigureAwait(false);
            }
            else if (initiative.SelectedAttack is MysticAttack mysticAttack)
            {
                initiative.AttackOrAimResolution = TryPayCastingCost(attacker, mysticAttack)
                    ? await MysticResolution.CreateAsync(
                        initiative,
                        rollService,
                        $"{name} - {Lng.Elem("Attack")}",
                        mysticAttack,
                        attackDirection).ConfigureAwait(false)
                    : MysticResolution.CreateOutOfPoints(mysticAttack, attackDirection);
            }
            else
            {
                initiative.AttackOrAimResolution = await AttackResolution.CreateAsync(
                    initiative,
                    rollService,
                    $"{name} - {Lng.Elem("Attack")}",
                    initiative.SelectedAttack,
                    attackDirection,
                    hitLocationTitle,
                    rollService is ManualCombatRollService).ConfigureAwait(false);
            }

            // Damage
            if (initiative.AttackOrAimResolution.IsSuccessful)
            {
                ApplyCombatDamage(initiative, attacker, target);

                if (initiative.SelectedAttack is PsiAttack { Discipline: { } discipline })
                {
                    discipline.OnHit(attacker, target);
                }
                else if (initiative.SelectedAttack is SpellAttack { Spell: { } spell })
                {
                    spell.OnHit(attacker, target);
                }
            }

            turn.Initiatives.Add(initiative);

            AddStateChanges(turn, attacker, attackerWasDead, attackerWasConscious);
            AddStateChanges(turn, target, targetWasDead, targetWasConscious);
        }
    }

    private static bool TryPayCastingCost(Attacker attacker, MysticAttack attack)
    {
        switch (attack)
        {
            case PsiAttack psiAttack when attacker is Character character:
                if (character.PsiPoints < psiAttack.PsiPointCost)
                {
                    return false;
                }
                character.PsiPoints -= psiAttack.PsiPointCost;
                return true;

            case PsiAttack psiAttack when attacker is Creature creature:
                if (creature.PsiPoints < psiAttack.PsiPointCost)
                {
                    return false;
                }
                creature.PsiPoints -= psiAttack.PsiPointCost;
                return true;

            case SpellAttack spellAttack when attacker is Character character:
                if (character.ManaPoints < spellAttack.ManaCost)
                {
                    return false;
                }
                if (spellAttack.PainTolerancePointCost > 0 && character.ActualPainTolerancePoints is int characterFp && characterFp < spellAttack.PainTolerancePointCost)
                {
                    return false;
                }
                character.ManaPoints -= spellAttack.ManaCost;
                if (spellAttack.PainTolerancePointCost > 0 && character.ActualPainTolerancePoints.HasValue)
                {
                    character.ActualPainTolerancePoints -= spellAttack.PainTolerancePointCost;
                }
                return true;

            case SpellAttack spellAttack when attacker is Creature creature:
                if (creature.ManaPoints < spellAttack.ManaCost)
                {
                    return false;
                }
                if (spellAttack.PainTolerancePointCost > 0 && creature.ActualPainTolerancePoints is int creatureFp && creatureFp < spellAttack.PainTolerancePointCost)
                {
                    return false;
                }
                creature.ManaPoints -= spellAttack.ManaCost;
                if (spellAttack.PainTolerancePointCost > 0 && creature.ActualPainTolerancePoints.HasValue)
                {
                    creature.ActualPainTolerancePoints -= spellAttack.PainTolerancePointCost;
                }
                return true;

            default:
                return false;
        }
    }

    /// <summary>
    /// Casts a spell/discipline outside of a running Encounter (e.g. from the CharDetails "care"
    /// panel) - on self or another saved character - reusing the exact same resolution rules a live
    /// combat turn would (TryPayCastingCost, MysticResolution's hit/crit/fumble roll, ApplyCombatDamage's
    /// HP-vs-FP routing, and the spell/discipline's own OnHit), just without a real Encounter/turn
    /// around it. Returns false if the caster can't afford it or the cast simply misses.
    /// </summary>
    public static async Task<bool> CastOutsideCombatAsync(Character caster, Character target, MysticAttack attack, ICombatRollService rollService)
    {
        if (!TryPayCastingCost(caster, attack))
        {
            return false;
        }

        var initiative = new InitiativeEntry
        {
            Attacker = new CombatantRef(caster),
            Target = new CombatantRef(target),
            SelectedAttack = attack,
            BaseInitiative = 0,
            RolledValue = 0
        };

        var resolution = await MysticResolution.CreateAsync(initiative, rollService, "Cast", attack, AttackDirection.Front).ConfigureAwait(false);
        initiative.AttackOrAimResolution = resolution;

        if (resolution.IsSuccessful)
        {
            ApplyCombatDamage(initiative, caster, target);

            if (attack is PsiAttack { Discipline: { } discipline })
            {
                discipline.OnHit(caster, target);
            }
            else if (attack is SpellAttack { Spell: { } spell })
            {
                spell.OnHit(caster, target);
            }
        }

        return resolution.IsSuccessful;
    }

    private static void AddStateChanges(TurnData turn, Attacker attacker, bool wasDead, bool wasConscious)
    {
        if (!wasDead && attacker.IsDead)
        {
            AddSpecialInitiative(turn, attacker, InitiativeEntryKind.Death);
            return;
        }

        if (wasConscious && !attacker.IsConscious && !attacker.IsDead)
        {
            AddSpecialInitiative(turn, attacker, InitiativeEntryKind.LostConsciousness);
        }
    }

    private static void AddSpecialInitiative(TurnData turn, Attacker attacker, InitiativeEntryKind kind)
    {
        var initiative = new InitiativeEntry
        {
            Kind = kind,
            Attacker = new CombatantRef(attacker),
            Target = new CombatantRef(attacker),
            SelectedAttack = null,
            BaseInitiative = 0,
            RolledValue = 0
        };

        turn.Initiatives.Add(initiative);
    }

    private static void ApplyCombatDamage(InitiativeEntry initiative, Attacker attacker, Attacker target)
    {
        if (attacker.IsDead || target.IsDead)
        {
            return;
        }

        var resolution = initiative.AttackOrAimResolution;
        if (resolution == null)
        {
            return;
        }

        if (resolution.IsHpDamage || !target.IsConscious)
        {
            var impact = resolution.Impact;
            switch (impact)
            {
                case AttackImpact.FatalMistake:
                    attacker.ActualHealthPoints -= resolution.Damage;
                    break;
                case AttackImpact.CriticalDamage:
                    target.Armor?.DecreaseArmorClass();
                    target.ActualHealthPoints -= resolution.Damage + 3;
                    break;
                default:
                    if (!resolution.BypassesArmor)
                    {
                        resolution.ReduceDamge(Math.Max(0, target.Armor?.ArmorClass ?? 0));
                    }
                    target.ActualHealthPoints -= resolution.Damage;
                    break;
            }
        }
        else
        {
            var impact = resolution.Impact;
            switch (impact)
            {
                case AttackImpact.FatalMistake:
                    attacker.ActualPainTolerancePoints -= resolution.Damage;
                    break;
                case AttackImpact.CriticalDamage:
                    target.Armor?.DecreaseArmorClass();
                    target.ActualHealthPoints -= 3;
                    target.ActualPainTolerancePoints -= resolution.Damage;
                    break;
                default:
                    if (!resolution.BypassesArmor)
                    {
                        resolution.ReduceDamge(Math.Max(0, target.Armor?.ArmorClass ?? 0));
                    }
                    target.ActualPainTolerancePoints -= resolution.Damage;
                    break;
            }
        }

        if (!target.IsDead && initiative.SelectedAttack is MysticAttack { DurationInRounds: > 1 } mysticAttack)
        {
            target.ActiveEffects.Add(new ActiveEffect(mysticAttack.Name, mysticAttack.GetDamage, resolution.IsHpDamage, mysticAttack.DurationInRounds - 1));
        }
    }
}