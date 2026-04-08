using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Maasym : Creature
{
    public Maasym()
    {
        Armor = new NaturalArmor(4);
        Occurrence = Occurrence.Frequent;
        Size = Size.Small; // Size.Human
        PlacesOfOccurrence = TerrainType.Desert;

        AttackValue = 48;
        DefenseValue = 70; // 90 a csápokra -> CombatModifier?
        InitiateValue = 20;
        AimValue = 0;

        AttacksPerRound = 2;

        HealthPoints = 16;
        PainTolerancePoints = 34;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 35;
    }

    public override string Name => "Maasym (giant ant)";

    public override string[] Images => ["maasym.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._2D10)]
    public override int GetNumberAppearing() => DiceThrow._2D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];
}