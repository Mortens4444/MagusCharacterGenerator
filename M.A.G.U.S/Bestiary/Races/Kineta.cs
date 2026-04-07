using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Kineta : Creature
{
    public Kineta()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Forest | TerrainType.Grassland | TerrainType.OldDilapidatedBuilding;

        AttackValue = 25;
        DefenseValue = 115;
        InitiateValue = 35;
        AimValue = 5;

        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue)
        ];

        HealthPoints = 4;
        PainTolerancePoints = 18;

        AstralMagicResistance = 19;
        MentalMagicResistance = 12;
        PoisonResistance = 3;

        Psi = new PsiPyarron();
        PsiPoints = 150;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosLife;
        ExperiencePoints = 155;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetNumberAppearing() => DiceThrow._1D6() + 2;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 75)];
}