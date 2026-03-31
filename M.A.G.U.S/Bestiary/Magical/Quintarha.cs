using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Magical;

public sealed class Quintarha : Creature
{
    public Quintarha()
    {
        Armor = new NaturalArmor(6);
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 75;
        DefenseValue = 125;
        InitiateValue = 40;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left strike", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Right strike", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 30;
        PainTolerancePoints = 80;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;
        //PsiResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.OrderDeath;
        ExperiencePoints = 1250;
    }

    public override double AttacksPerRound => 3;

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new(TravelMode.OnLand, 110)];
}