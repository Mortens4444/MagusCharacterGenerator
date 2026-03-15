using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class ArmoredRhino : Creature
{
    public ArmoredRhino()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Grassland | TerrainType.Mountains;
        Armor = new NaturalArmor(6);

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Claw", ThrowType._2D10), AttackValue),
            new MeleeAttack(new BodyPart("Hoof", ThrowType._3D6), AttackValue)
        ];

        AttackValue = 85;
        DefenseValue = 70;
        InitiateValue = 8;

        HealthPoints = 66;
        PainTolerancePoints = 94;

        PoisonResistance = 6;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 70;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    [DiceThrow(ThrowType._1D2)]
    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override double AttacksPerRound => 1/2; // 1/4

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 160)];

    public override string Name => "Armored rhino";
}