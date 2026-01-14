using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class FrostGiant : Creature
{
    public FrostGiant()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size._4_to_5_5_meters;
        AttackValue = 80;
        DefenseValue = 95;
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
        HealthPoints = 30;
        PainTolerancePoints = 100;
        AstralMagicResistance = 8;
        MentalMagicResistance = 35;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.LifeOrder;
        ExperiencePoints = 560;
    }

    public override string Name => "Frost giant (Iteyy)";

    public override string[] Images => ["frost_giant.png"];

    [DiceThrow(ThrowType._3D10)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._3D10() + 4;

    [DiceThrow(ThrowType._10D10)]
    public override int GetNumberAppearing() => DiceThrow._10D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}
