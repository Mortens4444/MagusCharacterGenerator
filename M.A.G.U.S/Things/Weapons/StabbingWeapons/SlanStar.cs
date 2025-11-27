using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SlanStar : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 3;

    public byte InitiatingValue => 10;

    public byte AttackingValue => 4;

    public byte DefendingValue => 4;

    public override double Weight => 0.1;

    public override Money Price => new(0, 0, 40);

    [DiceThrow(ThrowType._1K3)]
    public byte GetDamage() => (byte)DiceThrow._1K3();

    public override string Name => "Slan star";

    public override string Description => "A deadly, multi-pointed throwing weapon often associated with the Slan. It rotates when thrown, dealing severe, jagged cuts to the target.";
}