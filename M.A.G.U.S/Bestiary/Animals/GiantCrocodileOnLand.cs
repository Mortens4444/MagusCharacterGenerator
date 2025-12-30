using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class GiantCrocodileOnLand : Creature
{
    public GiantCrocodileOnLand()
    {
        ArmorClass = 8;
        Occurrence = Occurrence.Rare;
        Size = Size.Up_to_15_meters;
        AttackValue = 65;
        DefenseValue = 80;
        InitiateValue = 30;
        HealthPoints = 55;
        PainTolerancePoints = 110;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 310;
    }

    public override string Name => "Giant crocodile (on land)";

    public override string[] Images => ["giant_crocodile.png"];

    [DiceThrow(ThrowType._5D6)]
    public override int GetDamage() => DiceThrow._5D6();

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 30), new Speed(TravelMode.InWater, 120)];
}
