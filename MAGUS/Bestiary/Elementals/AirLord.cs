using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Elementals;

public sealed class AirLord : ElementalLord
{
    public AirLord()
    {
        Size = Size.Human;

        AttackValue = 80;
        DefenseValue = 180;
        InitiateValue = 60;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Air strike", ThrowType._1D10), AttackValue)
        ];

        HealthPoints = 60;

        ExperiencePoints = 15000;
    }

    public override string Name => "Air Lord";

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 140)];
}