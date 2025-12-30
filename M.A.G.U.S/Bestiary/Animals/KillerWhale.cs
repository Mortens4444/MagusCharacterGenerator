using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class KillerWhale : Creature
{
    public KillerWhale()
    {
        Occurrence = Occurrence.Rare;
        Intelligence = Enums.Intelligence.Average;
        Size = Size._4_meters;
        InitiateValue = 5;
        AttackValue = 95;
        DefenseValue = 70;
        HealthPoints = 30;
        PainTolerancePoints = 68;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 8;
        ExperiencePoints = 20;
    }

    public override string Name => "Killer whale";

    [DiceThrow(ThrowType._3D10)]
    public override int GetDamage() => DiceThrow._3D10();


    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.InWater, 120)];
}
