using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class BlueLizard : Creature
{
    public BlueLizard()
    {
        Armor = new NaturalArmor(3);
        Occurrence = Occurrence.Rare;
        Size = Size.Huge;
        PlacesOfOccurrence = TerrainType.Jungle | TerrainType.TropicalForest;

        AttackValue = 140;
        DefenseValue = 190;
        InitiateValue = 20;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._3D10, 10), AttackValue)
        ];

        HealthPoints = 55;
        PainTolerancePoints = 130;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        ExperiencePoints = 3250;
    }

    public override string Name => "Blue Lizard";

    [DiceThrow(ThrowType._3D10)]
    [DiceThrowModifier(10)]
    public override int GetDamage() => DiceThrow._3D10() + 10;

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}