using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Shadowwalker : Creature
{
    public Shadowwalker()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        AttackValue = 75;
        DefenseValue = 135;
        InitiateValue = 55;
        AimValue = 60;
        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];
        HealthPoints = 16;
        //PainTolerancePoints = 65 + DiceThrow._2D10();
        MinPainTolerancePoints = 67;
        MaxPainTolerancePoints = 85;
        AstralMagicResistance = 12;
        MentalMagicResistance = 9;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.High;
        ExperiencePoints = 350;
    }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._1D6() + 4;

    [DiceThrow(ThrowType._1D100)]

    public override int GetNumberAppearing() => DiceThrow._1D100();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
