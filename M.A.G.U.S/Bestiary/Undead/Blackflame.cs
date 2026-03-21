using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Blackflame : LivingDead
{
    public Blackflame()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 85;
        DefenseValue = 100;
        InitiateValue = 25;
        AimValue = 50;

        HealthPoints = 30;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Order;
        ExperiencePoints = 3000;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}