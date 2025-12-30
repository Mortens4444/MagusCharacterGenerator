using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class WhiteWolf : Creature
{
    public WhiteWolf()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        AttackValue = 30;
        DefenseValue = 50;
        InitiateValue = 10;
        HealthPoints = 18;
        PainTolerancePoints = 30;
        PoisonResistance = 4;
        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 3;
    }

    public override string Name => "White wolf";

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._3D10)]
    public override int GetNumberAppearing() => DiceThrow._3D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];

    public override string[] Sounds => ["wolf"];
}
