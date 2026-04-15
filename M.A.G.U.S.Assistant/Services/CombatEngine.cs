using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.CombatModifiers;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Utils;
using Mtf.Extensions;

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

        initiative.Attacker.RemoveTemporaryModifiers();
        var attackDirection = attacker.AttackDirection;

        if (attackDirection == AttackDirection.Behind)
        {
            var ambushMod = new AttackFromAmbush();
            initiative.Attacker.AddTemporaryModifier(ambushMod);
        }

        var (hitLocation, subLocation) = await HitLocationSelector.GetLocationAsync(attackDirection, rollService).ConfigureAwait(false);
        //var (hitLocation, subLocation) = HitLocationSelector.GetLocation(attackDirection);
        var locationDescription = hitLocation.GetDescription();
        if (initiative.SelectedAttack == null)
        {
            var speed = attacker.GetMaxMovementSpeed();
            assignment.DecreaseDistance(initiative.Attacker.Source, speed);
            return;
        }

        if (!target.IsConscious)
        {
            // Automatic damage
            //var baseDamage = await initiative.SelectedAttack.GetDamageAsync(rollService).ConfigureAwait(false);
            var baseDamage = initiative.SelectedAttack.GetDamage();
            var finalDamage = Math.Max(0, baseDamage - (target.Armor?.ArmorClass ?? 0));
            target.ActualHealthPoints -= finalDamage;

            initiative.AttackOrAimResolution = new ForcedResolution(initiative, finalDamage)
            {
                Attack = initiative.SelectedAttack!,
                Direction = attackDirection,
                HitLocation = locationDescription,
                HitSubLocation = subLocation
            };
        }
        else
        {
            if (initiative.SelectedAttack is RangedAttack)
            {
                var targetDistance = assignment.GetDistanceInMeters(initiative.Target.Source);
                initiative.AttackOrAimResolution = new AimResolution(initiative, targetDistance, MovementType.Predictable, WeatherCondition.Clear)
                {
                    Attack = initiative.SelectedAttack,
                    Direction = attackDirection,
                    HitLocation = locationDescription,
                    HitSubLocation = subLocation
                };
            }
            else
            {
                initiative.AttackOrAimResolution = new AttackResolution(initiative)
                {
                    Attack = initiative.SelectedAttack,
                    Direction = attackDirection,
                    HitLocation = locationDescription,
                    HitSubLocation = subLocation
                };
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