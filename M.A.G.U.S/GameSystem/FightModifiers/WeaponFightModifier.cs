namespace M.A.G.U.S.GameSystem.FightModifiers;

public class WeaponFightModifier : IFightModifier
{
    public int InitiatingValue { get; set; }

    public int AttackValue { get; set; }

    public int DefenseValue { get; set; }

    public int? AimingValue { get; set; }
}
