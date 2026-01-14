using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class ForestGiant : Creature
{
    public ForestGiant()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.About_7_meters;
        AttackValue = 100;
        DefenseValue = 155;
        InitiateValue = 30;
        AimValue = 30;
        //AttackModes =
        //[
        //    new MeleeAttack(new Warhammer(), AttackValue),
        //    new MeleeAttack(new TwoHandedMace(), AttackValue),
        //    new MeleeAttack(new ShortSword(), AttackValue),
        //    new MeleeAttack(new Longsword(), AttackValue),
        //    new RangeAttack(new Shortbow(), AimValue),
        //    new RangeAttack(new Longbow(), AimValue)
        //];
        HealthPoints = 22;
        PainTolerancePoints = 98;
        AstralMagicResistance = 7;
        MentalMagicResistance = 25;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.Average;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 720;
    }

    public override string Name => "Forest giant (Traclon)";

    public override string[] Images => ["forest_giant.png"];

    [DiceThrow(ThrowType._4D10)]
    [DiceThrowModifier(5)]
    public override int GetDamage() => DiceThrow._4D10() + 5;

    [DiceThrow(ThrowType._4D10)]
    public override int GetNumberAppearing() => DiceThrow._4D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 130)];
}
