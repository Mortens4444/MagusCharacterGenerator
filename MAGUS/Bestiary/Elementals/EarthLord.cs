using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Elementals;

public sealed class EarthLord : ElementalLord
{
    public EarthLord()
    {
        Size = Size.Huge;

        AttackValue = 120;
        DefenseValue = 120;
        InitiateValue = 30;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Earth strike", ThrowType._10D10), AttackValue)
        ];

        HealthPoints = 60;

        ExperiencePoints = 25000;
    }

    public override string Name => "Earth Lord";

    [DiceThrow(ThrowType._10D10)]
    public override int GetDamage() => DiceThrow._10D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}