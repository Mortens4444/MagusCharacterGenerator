using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Sicchel : Creature
{
    public Sicchel()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 35;
        DefenseValue = 85;
        InitiateValue = 14;

        HealthPoints = 9;
        PainTolerancePoints = 35;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 65;
    }

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];

    //public override string[] Sounds => ["mad_laugh", "mad_moan"];
}