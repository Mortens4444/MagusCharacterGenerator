using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class Warhammer : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 5;

    public byte AttackingValue => 10;

    public byte DefendingValue => 8;

    public override double Weight => 3;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 2);

    public override string Description => "A weapon designed to defeat armour, featuring a heavy blunt head for crushing and a long, slender spike on the reverse for piercing plates.";
}