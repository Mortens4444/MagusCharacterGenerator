using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class CommonRhino : Creature
{
    public CommonRhino()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Grassland | TerrainType.Savanna;
        Armor = new NaturalArmor(3);

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Claw", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Hoof", ThrowType._2D6), AttackValue)
        ];

        AttackValue = 65;
        DefenseValue = 90;
        InitiateValue = 12;

        HealthPoints = 40;
        PainTolerancePoints = 72;

        PoisonResistance = 4;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 40;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D3)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override double AttacksPerRound => 1; // 1/3

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140)];

    public override string Name => "Common rhino";
}
