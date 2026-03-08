using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Gnome : Creature
{
    public Gnome()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Cave;

        AttackValue = 45;
        DefenseValue = 70;
        InitiateValue = 15;
        AimValue = 20;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Dagger(), AttackValue),
            new RangedAttack(new KahreiCrossbow(), AimValue),
        ];

        HealthPoints = 15;
        PainTolerancePoints = 25;

        PoisonResistance = 3;
        MentalMagicResistance = 30; // Speciális
        AstralMagicResistance = 25; // Változó

        MinIntelligence = Enums.Intelligence.Low;
        MaxIntelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.Order;
        ExperiencePoints = 25;
    }

    [DiceThrow(ThrowType._10D10)]
    public override int GetNumberAppearing() => DiceThrow._10D10();

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];
}