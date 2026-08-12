using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;

namespace MAGUS.Bestiary.Undead;

public sealed class Mummy : LivingDead
{
    public Mummy()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 70;
        DefenseValue = 110;
        InitiateValue = 20;

        HealthPoints = 18;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        //Psi = as in life
        ExperiencePoints = 3000; // For a 10th level priest
        NecrographyDepartment = NecrographyDepartment.NightMonster;
    }

    public override string Name => "Mummy (Muliphein)";

    public override string[] Images => ["mummy.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];
}
