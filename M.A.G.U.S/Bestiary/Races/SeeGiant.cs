using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class SeeGiant : Creature
{
    public SeeGiant()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.About_8_meters;
        AttackValue = 85;
        DefenseValue = 135;
        InitiateValue = 35;
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
        HealthPoints = 30;
        PainTolerancePoints = 120;
        AstralMagicResistance = 6;
        MentalMagicResistance = 30;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.DeathChaos;
        ExperiencePoints = 650;
    }

    public override string Name => "See giant (Vaynak)";

    public override string[] Images => ["see_giant.png"];

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._4D10)]
    [DiceThrowModifier(5)]
    public override int GetDamage() => DiceThrow._4D10() + 5;

    [DiceThrow(ThrowType._4D10)]
    public override int GetNumberAppearing() => DiceThrow._4D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110), new Speed(TravelMode.InWater, 90)];
}
