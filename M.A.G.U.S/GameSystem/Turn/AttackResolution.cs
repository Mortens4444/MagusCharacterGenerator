namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AttackResolution : ResolutionBase
{
    public AttackResolution(InitiativeEntry initiative)
    {
        RollValue = initiative.Attacker.Source.RollAttack();
        var attack = initiative.Attacker.Source.AttackValue + RollValue;

        IsSuccessful = attack > initiative.Target.Source.DefenseValue;
        IsHpDamage = attack > initiative.Target.Source.DefenseValue + OverHitValue;
    }
}
