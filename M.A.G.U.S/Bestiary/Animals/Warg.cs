using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class Warg : Creature
{
    public Warg()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Forest | TerrainType.Mountains;

        AttackValue = 55;
        DefenseValue = 75;
        InitiateValue = 22;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6, 1), AttackValue)
        ];

        HealthPoints = 22;
        PainTolerancePoints = 57;

        PoisonResistance = 5;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 30;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    [DiceThrow(ThrowType._3D6)]
    public override int GetNumberAppearing() => DiceThrow._3D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];

    //public override string[] Sounds => ["warg_growl", "warg_howl"];
}