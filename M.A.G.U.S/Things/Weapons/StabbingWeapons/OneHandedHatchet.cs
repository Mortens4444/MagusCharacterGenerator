using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class OneHandedHatchet : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiatingValue => 5;

    public int AttackingValue => 12;

    public int DefendingValue => 11;

    public override double Weight => 2;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Name => "One-handed axe";

    public override string Description => "A simple, single-handed axe used for both labour and combat. An inexpensive and versatile sidearm.";
}