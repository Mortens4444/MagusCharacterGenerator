using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Armors;

namespace MAGUS.Bestiary.Mythical;

public sealed class Fhyanra : Creature
{
    public Fhyanra()
    {
        Armor = new NaturalArmor(6);
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 80;
        DefenseValue = 130;
        InitiateValue = 30;
        AimValue = 30;

        AttacksPerRound = 2;

        HealthPoints = 20;
        PainTolerancePoints = 60;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;

        Alignment = Alignment.OrderDeath;
        ExperiencePoints = 450;
    }

    public override string Name => "Fh'yanra, the Herald";

    public override string[] Images => ["fh_yanra.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 110)];
}
