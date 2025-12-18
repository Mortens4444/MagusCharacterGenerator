using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class Longbow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiatingValue => 4;

    public int AimingValue => 6;

    public int Distance => 110;

    public override double Weight => 0.7;

    public override Money Price => new(3, 5);

    [DiceThrow(ThrowType._1D6_Ranged)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6_RangedAttack() + 1;

    public override string Description => "A tall bow made of a single stave of yew or ash. Requires great strength and practice to master, but fires arrows with devastating range and power.";
}