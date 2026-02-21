using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Nardael : Creature
{
    public Nardael()
    {
        const int MasterAiming = 10;
        const int ElvenBowAimValue = 10;

        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        AttackValue = 50; // 50-100
        DefenseValue = 145; // 90-200
        InitiateValue = 42; // 25-60
        AimValue = 42; // 10-75
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Magical sword (weak)", ThrowType._2D6), 50),
            new MeleeAttack(new BodyPart("Magical sword (powerful)", ThrowType._2D6), 100),
            new RangedAttack(new BreathWeapon("Magical elven bow (weak)", ThrowType._2D6_Ranged), 10 + ElvenBowAimValue + MasterAiming),
            new RangedAttack(new BreathWeapon("Magical elven bow (powerful)", ThrowType._2D6_Ranged), 75 + ElvenBowAimValue + MasterAiming)
        ];
        AttacksPerRound = 2;
        MinHealthPoints = 10;
        MaxHealthPoints = 50;
        MinPainTolerancePoints = 40;
        MaxPainTolerancePoints = 175;
        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Enums.Alignment.Life;
        ExperiencePoints = 20000;
    }

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}
