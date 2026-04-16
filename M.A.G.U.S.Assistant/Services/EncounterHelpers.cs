using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Services;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;
using System.Linq;

namespace M.A.G.U.S.Assistant.Services;

internal static class EncounterHelpers
{
    public static Task<List<InitiativeEntry>> GetInitiativesAsync(AssignmentViewModel assignment, TurnData turn, ICombatRollService rollService)
    {
        var result = GetInitiatives(assignment, turn, rollService).ToList();
        return Task.FromResult(result);
    }

    public static IOrderedEnumerable<InitiativeEntry> GetInitiatives(AssignmentViewModel assignment, TurnData turn) => GetInitiatives(assignment, turn, new AutoCombatRollService());

    public static IOrderedEnumerable<InitiativeEntry> GetInitiatives(AssignmentViewModel assignment, TurnData turn, ICombatRollService rollService)
    {
        var result = new List<InitiativeEntry>();
        if (!assignment.Enemies.Any())
        {
            return result.OrderByDescending(initiative => initiative.FinalInitiative);
        }

        foreach (var enemy in assignment.Enemies.ToList())
        {
            if (!enemy.IsConscious)
            {
                continue;
            }
            int dist = assignment.GetDistanceInMeters(enemy);
            var intendedAttack = enemy.GetRandomAttackMode(); // Need an attack mode provider like ICombatRollService
            int range = Attacker.GetAttackRangeInMeters(intendedAttack);
            if (dist > range)
            {
                int speed = enemy.GetMaxMovementSpeed();
                assignment.DecreaseDistance(enemy, speed);
                AddInitiative(new CombatantRef(enemy), new CombatantRef(assignment.Character), null, result, rollService);
                continue;
            }

            if (result.Count < assignment.MaxSimultaneousAttacks)
            {
                int attackCount = enemy.GetAttackCountForRound(turn.Round); // Shouldn't it use intendedAttack also to determinate the attack count?
                for (var i = 0; i < attackCount; i++)
                {
                    AddInitiative(new CombatantRef(enemy), new CombatantRef(assignment.Character), intendedAttack, result, rollService);
                }
            }
        }

        if (!assignment.Character.IsConscious)
        {
            return result.OrderByDescending(initiative => initiative.FinalInitiative);
        }

        var target = (Attacker)(assignment.Character.AttackStrategy switch
        {
            AttackStrategy.AttackFirst => assignment.Enemies.First(),
            AttackStrategy.AttackRandom => assignment.Enemies[RandomProvider.GetSecureRandomInt(0, assignment.Enemies.Count)],
            AttackStrategy.AttackWeakest => assignment.Enemies.OrderBy(enemy => enemy.ActualHealthPoints).First(),
            AttackStrategy.AttackStrongest => assignment.Enemies.OrderBy(enemy => enemy.AttackValue).First(),
            _ => throw new NotImplementedException()
        });

        int characterAttackCount = assignment.Character.GetAttackCountForRound(turn.Round); // Same here with charIntendedAttack?
        var charIntendedAttack = assignment.Character.AttackModes.FirstOrDefault();
        int charDist = assignment.GetDistanceInMeters(target);

        for (var i = 0; i < characterAttackCount; i++)
        {
            AddInitiative(new CombatantRef(assignment.Character), new CombatantRef(target), charIntendedAttack, result, rollService);
        }
        return result.OrderByDescending(initiative => initiative.FinalInitiative);
    }

    private static void AddInitiative(CombatantRef attacker, CombatantRef target, Attack? attack, List<InitiativeEntry> result, ICombatRollService rollService)
    {
        var name = attacker.Source is Character character ? character.Name : Lng.Elem(attacker.Source.Name);
        var init = Lng.Elem("Initiative");
        result.Add(new InitiativeEntry
        {
            Attacker = attacker,
            Target = target,
            SelectedAttack = attack,
            BaseInitiative = attacker.Source.InitiateValue,
            RolledValue = rollService.RollInitiativeAsync($"{name} {init}").GetAwaiter().GetResult()
        });
    }
}
