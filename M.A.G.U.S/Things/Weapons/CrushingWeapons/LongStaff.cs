using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class LongStaff : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 4;

    public byte AttackingValue => 10;

    public byte DefendingValue => 16;

    public override double Weight => 1.2;

    public override Money Price => new(0, 0, 50);

    [DiceThrow(ThrowType._1D5)]
    public byte GetDamage() => (byte)DiceThrow._1D5();

    public override string Name => "Quarterstaff";

    public override string Description => "A six-foot pole of seasoned wood, often tipped with iron. The humble yet effective weapon of monks, pilgrims, and guards, used for sweeping, tripping, and bludgeoning.";
}