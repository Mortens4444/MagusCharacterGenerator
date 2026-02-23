using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Anatyda : Creature
{
    public Anatyda()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        AttackValue = 70;
        DefenseValue = 60;
        InitiateValue = 5;
        AttackModes =
        [
            new MeleeAttack(new ShortSword(), AttackValue),
            new MeleeAttack(new Dagger(), AttackValue),
            new MeleeAttack(new Knife(), AttackValue)
        ];
        HealthPoints = 8;
        PainTolerancePoints = 15;
        PoisonResistance = 5;
        AstralMagicResistance = 80;
        MentalMagicResistance = 70;
        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 200;
    }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D10() + 2;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 80)];
}
