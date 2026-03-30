using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Troll : Creature
{
    public Troll()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 85;
        DefenseValue = 120;
        InitiateValue = 40;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left claw", ThrowType._1D10, 3), AttackValue),
            new MeleeAttack(new BodyPart("Right claw", ThrowType._1D10, 3), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 45; //RegenerationPerRound = ThrowType._1D6;
        PainTolerancePoints = 110; //RegenerationPerRound = ThrowType._1D6;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;
        //PsiResistance = Int32.MaxValue;

        MinIntelligence = Enums.Intelligence.Low;
        MaxIntelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Death;
        ExperiencePoints = 850;

        //HasAcidBlood = true;
    }

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D10() + 3;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];

    //public override string[] Sounds => ["troll_roar", "troll_growl", "troll_attack"];
}