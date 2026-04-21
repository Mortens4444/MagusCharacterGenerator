using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.CombatModifiers;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Services;

internal class CombatEngine
{
    public static async Task ProcessAssignmentTurnAsync(AssignmentViewModel assignment, int round, ICombatRollService rollService)
    {
        var turn = new TurnData { Round = round };
        var initiatives = await EncounterHelpers.GetInitiativesAsync(assignment, turn, rollService).ConfigureAwait(false);
        turn.Initiatives.AddRange(initiatives);

        foreach (var initiative in turn.Initiatives)
        {
            await ProcessInitiativeAsync(initiative, assignment, rollService).ConfigureAwait(false);
        }

        if (initiatives.Count != 0)
        {
            assignment.AddTurn(turn);
        }
    }

    private static async Task ProcessInitiativeAsync(InitiativeEntry initiative, AssignmentViewModel assignment, ICombatRollService rollService)
    {
        Attacker attacker = initiative.Attacker.Source;
        Attacker target = initiative.Target.Source;
        
        if (attacker.IsDead || target.IsDead)
        {
            return;
        }

        if (!attacker.IsConscious)
        {
            return;
        }

        initiative.Attacker.RemoveTemporaryModifiers();
        var attackDirection = attacker.AttackDirection;

        if (attackDirection == AttackDirection.Behind)
        {
            var ambushMod = new AttackFromAmbush();
            initiative.Attacker.AddTemporaryModifier(ambushMod);
        }

        if (initiative.SelectedAttack == null)
        {
            var speed = attacker.GetMaxMovementSpeed();
            assignment.DecreaseDistance(initiative.Attacker.Source, speed);
            return;
        }

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
        }
        else
        {
            if (initiative.SelectedAttack is RangedAttack rangedAttack)
            {
                var targetDistance = assignment.GetDistanceInMeters(initiative.Target.Source);
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
            }
        }
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
                    resolution.ReduceDamge(Math.Max(0, target.Armor?.ArmorClass ?? 0));
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
                    resolution.ReduceDamge(Math.Max(0, target.Armor?.ArmorClass ?? 0));
                    target.ActualPainTolerancePoints -= resolution.Damage;
                    break;
            }
        }
    }
}