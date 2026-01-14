using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class MountainGiant : Creature
{
    public MountainGiant()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.About_8_5_meters;
        AttackValue = 110;
        DefenseValue = 170;
        InitiateValue = 20;
        AimValue = 0;
        //AttackModes =
        //[
        //    new MeleeAttack(new Warhammer(), AttackValue),
        //    new MeleeAttack(new TwoHandedMace(), AttackValue),
        //    new MeleeAttack(new ShortSword(), AttackValue),
        //    new MeleeAttack(new Longsword(), AttackValue),
        //    new RangeAttack(new Shortbow(), AimValue),
        //    new RangeAttack(new Longbow(), AimValue)
        //];
        HealthPoints = 45;
        PainTolerancePoints = 120;
        AstralMagicResistance = 5;
        MentalMagicResistance = 25;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.Average;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 850;
    }

    public override double AttacksPerRound => 2;

    public override string Name => "Mountain giant (Sacron)";

    public override string[] Images => ["mountain_giant.png"];

    [DiceThrow(ThrowType._4D10)]
    [DiceThrowModifier(6)]
    public override int GetDamage() => DiceThrow._4D10() + 6;

    [DiceThrow(ThrowType._6D10)]
    public override int GetNumberAppearing() => DiceThrow._6D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
