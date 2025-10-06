using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class KillerWhale : Creature
{
    public KillerWhale()
    {
        Occurrence = Occurrence.Rare;
        Intelligence = Intelligence.Average;
        Size = Size._4_meters;
        Speed = 120;
        AttackValue = 95;
        DefenseValue = 70;
        MaxHealthPoints = 30;
        HealthPoints = 30;
        MaxPainTolerancePoints = 68;
        PainTolerancePoints = 68;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;
        PoisonResistance = 8;
        ExperiencePoints = 20;
    }

    public override string Name => "Killer whale";

    [DiceThrow(ThrowType._3K10)]
    public override byte GetDamage() => (byte)DiceThrow._3K10();


    [DiceThrow(ThrowType._1K6)]
    public override byte GetNumberAppearing() => (byte)DiceThrow._1K6();
}
