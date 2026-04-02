using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class WargPackLeader : Creature
{
    public WargPackLeader()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Forest | TerrainType.Mountains;

        AttackValue = 65;
        DefenseValue = 85;
        InitiateValue = 22;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6, 1), AttackValue)
        ];

        HealthPoints = 29;
        PainTolerancePoints = 67;

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

    public override string Name => "Warg pack leader";

    public override string[] Sounds => ["werewolf_howl"]; //["warg_growl", "warg_howl"];
}