using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Orc : Creature
{
    public Orc()
    {
        Occurrence = Occurrence.Frequent;
        Size = Size.Human;
        AttackValue = 55;
        DefenseValue = 85;
        InitiateValue = 20;
        AimValue = 0;
        AttackModes =
        [
            new MeleeAttack(new Warhammer(), AttackValue),
            new MeleeAttack(new TwoHandedMace(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Longsword(), AttackValue),
            new RangedAttack(new Shortbow(), AimValue),
            new RangedAttack(new Longbow(), AimValue)
        ];
        HealthPoints = 10;
        PainTolerancePoints = 16;
        PoisonResistance = 3;
        Intelligence = Enums.Intelligence.Low;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 30;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrow(ThrowType._10D10)]
    public override int GetNumberAppearing() => DiceThrow._10D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}
