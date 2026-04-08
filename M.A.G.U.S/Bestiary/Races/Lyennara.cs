using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Lyennara : Creature
{
    public Lyennara()
    {
        Size = Size.Human;
        Alignment = Alignment.OrderLife;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 45;
        DefenseValue = 135;
        InitiateValue = 25;
        AimValue = 35;

        HealthPoints = 15;
        PainTolerancePoints = 98;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = 180;
        PoisonResistance = 19;

        ManaPoints = 160;

        Intelligence = Enums.Intelligence.Outstanding;
        ExperiencePoints = 35000;

        // Occurrence = see description;
        // Number appearing = see description;
        // Speed = variable;
        // Psi = see description;
        // Damage = weapon dependent;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // Weapon dependent

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1; // See description

    public override List<Speed> Speeds => [];
}