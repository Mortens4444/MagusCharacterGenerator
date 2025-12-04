using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class OneHandedHatchet : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 5;

    public byte AttackingValue => 12;

    public byte DefendingValue => 11;

    public override double Weight => 2;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1D10)]
    public byte GetDamage() => (byte)DiceThrow._1D10();

    public override string Name => "One-handed axe";

    public override string Description => "A simple, single-handed axe used for both labour and combat. An inexpensive and versatile sidearm.";
}