using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Seyrine : Creature
{
    public Seyrine()
    {
        Occurrence = Occurrence.Summoned;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Size = Size.Human;

        AttackValue = 20;
        DefenseValue = 80;
        InitiateValue = 16;
        AimValue = 6;

        HealthPoints = 12;

        AstralMagicResistance = Int32.MaxValue; //38
        MentalMagicResistance = Int32.MaxValue; //34
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Outstanding;

        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 1000;
    }

    public override string Name => "Seyrine (the Tormentor)";

    public override string[] Images => ["seyrine.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override int GetDamage() => 0; // fegyver szerint

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}