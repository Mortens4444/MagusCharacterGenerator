using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Turn;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Assistant.Services;

internal static class EncounterHelpers
{
    public static IOrderedEnumerable<InitiativeEntry> GetInitiatives(AssignmentViewModel assignment, TurnData turn)
    {
        var result = new List<InitiativeEntry>();
        if (!assignment.Enemies.Any())
        {
            return result.OrderByDescending(initiative => initiative.FinalInitiative);
        }

        foreach (var enemy in assignment.Enemies.ToList())
        {
            int dist = assignment.GetDistanceInMeters(enemy);
            var intendedAttack = enemy.GetRandomAttackMode();
            int range = Attacker.GetAttackRangeInMeters(intendedAttack);
            if (dist > range)
            {
                int speed = enemy.GetMaxMovementSpeed();
                assignment.DecreaseDistance(enemy, speed);
                AddInitiative(new CombatantRef(enemy), new CombatantRef(assignment.Character), null, result);
                continue;
            }

            int attackCount = enemy.GetAttackCountForRound(turn.Round);
            for (var i = 0; i < attackCount; i++)
            {
                AddInitiative(new CombatantRef(enemy), new CombatantRef(assignment.Character), intendedAttack, result);
            }
        }

        var target = (Attacker)(assignment.Character.AttackStrategy switch
        {
            AttackStrategy.AttackFirst => assignment.Enemies.First(),
            AttackStrategy.AttackRandom => assignment.Enemies[RandomProvider.GetSecureRandomInt(0, assignment.Enemies.Count)],
            AttackStrategy.AttackWeakest => assignment.Enemies.OrderBy(enemy => enemy.ActualHealthPoints).First(),
            AttackStrategy.AttackStrongest => assignment.Enemies.OrderBy(enemy => enemy.AttackValue).First(),
            _ => throw new NotImplementedException()
        });

        int characterAttackCount = assignment.Character.GetAttackCountForRound(turn.Round);
        var charIntendedAttack = assignment.Character.AttackModes.FirstOrDefault();
        int charDist = assignment.GetDistanceInMeters(target);

        for (var i = 0; i < characterAttackCount; i++)
        {
            AddInitiative(new CombatantRef(assignment.Character), new CombatantRef(target), charIntendedAttack, result);
        }
        return result.OrderByDescending(initiative => initiative.FinalInitiative);
    }

    private static void AddInitiative(CombatantRef attacker, CombatantRef target, Attack? attack, List<InitiativeEntry> result)
    {
        result.Add(new InitiativeEntry
        {
            Attacker = attacker,
            Target = target,
            SelectedAttack = attack,
            BaseInitiative = attacker.Source.InitiateValue,
            RolledValue = attacker.Source.RollInitiative()
        });
    }
}
