using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Wakrara : Creature
{
    public Wakrara()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;

        AttackValue = 120;
        DefenseValue = 155;
        InitiateValue = 40;
        AimValue = 35;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._3D6, 4), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._3D6, 4), AttackValue)
        ];

        HealthPoints = 45;
        PainTolerancePoints = 90;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Psi = new PsiPyarron();
        PsiPoints = 100;
        ManaPoints = 300; // 3 * 100

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 18000;
    }

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._3D6)]
    [DiceThrowModifier(4)]
    public override int GetDamage() => DiceThrow._3D6() + 4;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}