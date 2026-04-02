using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Yersenia : Creature
{
    public Yersenia()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 75;
        DefenseValue = 80;
        InitiateValue = 8;
        AimValue = 45;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Pseudopod strike", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 35;
        PainTolerancePoints = 75;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Death;
        ExperiencePoints = 250;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override double AttacksPerRound => 3;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40)];
}