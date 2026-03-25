using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Carnomak : LivingDead
{
    public Carnomak()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Water;

        DefenseValue = 15;
        InitiateValue = 15;

        HealthPoints = 5;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Death;
        ExperiencePoints = 150;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();
    
    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    public override List<Speed> Speeds => [];
}