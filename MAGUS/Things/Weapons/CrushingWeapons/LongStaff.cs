using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.CrushingWeapons;

public class LongStaff : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 4;

    public int AttackValue => 10;

    public int DefenseValue => 16;

    public override double Weight => 1.2;

    public override Money Price => new(0, 0, 50);

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5();

    public override string Name => "Quarterstaff";

    public override string Description => "A six-foot pole of seasoned wood, often tipped with iron. The humble yet effective weapon of monks, pilgrims, and guards, used for sweeping, tripping, and bludgeoning.";
}