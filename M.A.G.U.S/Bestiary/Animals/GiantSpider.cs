using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class GiantSpider : Creature
{
    public GiantSpider()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        AttackValue = 30;
        DefenseValue = 60;
        InitiatingValue = 25;
        HealthPoints = 6;
        PainTolerancePoints = 13;
        PoisonResistance = 8;
        Intelligence = Enums.Intelligence.Animal;
        ArmorClass = 2;
        ExperiencePoints = 0;
    }

    public override string Name => "Giant spider";

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}
