using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class SwampGiant : Creature
{
    public SwampGiant()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.About_6_meters;
        AttackValue = 75;
        DefenseValue = 125;
        InitiateValue = 25;
        AimValue = 0;
        //AttackModes =
        //[
        //    new MeleeAttack(new ShortSword(), AttackValue), // Traclon tőr TÉ: 12, VÉ: 14, KÉ: 9, Sebzés: 1k10+4
        //    new MeleeAttack(new Warhammer(), AttackValue), // Traclon egykezes kard TÉ: 14, VÉ: 16, KÉ: 6, Sebzés: 3k10+4
        //    new MeleeAttack(new TwoHandedMace(), AttackValue),
        //    new MeleeAttack(new Longsword(), AttackValue),
        //    new RangeAttack(new Shortbow(), AimValue),
        //    new RangeAttack(new Longbow(), AimValue) // Sacron Vadászathoz íjat és hajítódárdáka
        //];
        HealthPoints = 20;
        PainTolerancePoints = 100;
        AstralMagicResistance = 4;
        MentalMagicResistance = 25;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 610;
    }

    public override string Name => "Swamp giant (Voul)";

    public override string[] Images => ["swamp_giant.png"];

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._3D10)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._3D10() + 4;

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100), new Speed(TravelMode.InWater, 40)];
}
