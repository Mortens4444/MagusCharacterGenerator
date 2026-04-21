using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class CommonHorse : Creature
{
    public CommonHorse()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Big;

        AttackValue = RandomProvider.GetSecureRandomInt(5, 11);
        DefenseValue = RandomProvider.GetSecureRandomInt(45, 61);
        InitiateValue = 6;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", GetCustomDamage()), AttackValue),
            new MeleeAttack(new BodyPart("Hoof strike", GetCustomDamage()), AttackValue),
            new MeleeAttack(new BodyPart("Kick", GetCustomDamage()), AttackValue)
        ];

        HealthPoints = RandomProvider.GetSecureRandomInt(20, 31);
        PainTolerancePoints = RandomProvider.GetSecureRandomInt(30, 51);

        PoisonResistance = RandomProvider.GetSecureRandomInt(2, 4);

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 10;
    }

    private static ThrowType GetCustomDamage()
    {
        var damageType = RandomProvider.GetSecureRandomInt(0, 3);
        return damageType switch
        {
            0 => ThrowType._1D3,
            1 => ThrowType._1D4,
            _ => ThrowType._1D5
        };
    }

    public override string Name => "Horse";

    public override string[] Images => ["horse_traveler.png"];

    public override int GetDamage()
    {
        return AttackModes[0].GetDamage();
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, RandomProvider.GetSecureRandomInt(60, 221))];
}
