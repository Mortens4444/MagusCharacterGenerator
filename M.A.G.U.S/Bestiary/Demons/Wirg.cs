using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Wirg : Creature
{
    public Wirg()
    {
        Occurrence = Occurrence.Summoned;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 40;
        DefenseValue = 80;
        InitiateValue = 36;
        AimValue = 10;

        HealthPoints = 4;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        ManaPoints = 80;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 850;
    }

    public override string Name => "Wirg (the Depraved)";

    public override string[] Images => ["wirg.png"];

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0; // Fegyver szerint

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40), new Speed(TravelMode.InTheAir, 120)];
}