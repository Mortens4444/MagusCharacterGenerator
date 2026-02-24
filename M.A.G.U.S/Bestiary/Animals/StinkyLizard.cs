using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class StinkyLizard : Creature
{
    public StinkyLizard()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;

        AttackValue = 75;
        DefenseValue = 115;
        InitiateValue = 30;
        AimValue = 40;

        //AttackModes =
        //[
        //    new MeleeAttack(new NaturalClaw("Ütés I", DamageType.Blunt, DiceThrow._1D6), AttackValue),
        //    new MeleeAttack(new NaturalClaw("Ütés II", DamageType.Blunt, DiceThrow._1D6), AttackValue),
        //    new MeleeAttack(new NaturalBite("Harapás", DiceThrow._1D10), AttackValue),
        //    new RangedAttack(new NaturalSpit("Méregköpés", 30), AimValue)
        //];

        HealthPoints = 28;
        PainTolerancePoints = 62;

        PoisonResistance = 5;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 70;
        Alignment = Enums.Alignment.None;
    }

    public override string Name => "Stinky Lizard";

    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [ new Speed(TravelMode.OnLand, 75), new Speed(TravelMode.InWater, 120) ];
}