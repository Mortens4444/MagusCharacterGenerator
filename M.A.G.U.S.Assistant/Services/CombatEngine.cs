using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.CombatModifiers;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.Assistant.Services;

internal class CombatEngine
{
    public void ProcessAssignmentTurn(AssignmentViewModel assignment, int round)
    {
        var turn = new TurnData { Round = round };
        var initiatives = EncounterHelpers.GetInitiatives(assignment, turn).ToList();
        turn.Initiatives.AddRange(initiatives);

        foreach (var initiative in turn.Initiatives)
        {
            ProcessInitiative(initiative, assignment);
        }

        if (initiatives.Count != 0)
        {
            assignment.AddTurn(turn);
        }
    }

    private void ProcessInitiative(InitiativeEntry initiative, AssignmentViewModel assignment)
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

        var (locationDescription, subLocation) = HitLocationSelector.GetLocation(attackDirection);
        if (initiative.SelectedAttack == null)
        {
            var speed = attacker.GetMaxMovementSpeed();
            assignment.DecreaseDistance(initiative.Attacker.Source, speed);
            return;
        }

        if (!target.IsConscious)
        {
            // Automatic damage
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