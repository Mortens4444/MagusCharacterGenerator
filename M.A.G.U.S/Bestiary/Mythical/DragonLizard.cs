using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class DragonLizard : Creature
{
    public DragonLizard()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Mountains;

        Armor = new NaturalArmor(10);

        AttackValue = 112;
        DefenseValue = 50;
        InitiateValue = 4;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._5D6), AttackValue),
            new MeleeAttack(new BodyPart("Claw strike", ThrowType._5D10), AttackValue),
            new MeleeAttack(new BodyPart("Tail strike", ThrowType._8D10), AttackValue)
        ];

        HealthPoints = 60;
        PainTolerancePoints = 140;

        AstralMagicResistance = 3;
        MentalMagicResistance = 3;
        PoisonResistance = 11;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Chaos;
        ExperiencePoints = 1850;
    }

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._5D6)]
    public override int GetDamage() => DiceThrow._5D6();

    public override double AttacksPerRound => 2;

    public override string Name => "Dragon Lizard";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];
}