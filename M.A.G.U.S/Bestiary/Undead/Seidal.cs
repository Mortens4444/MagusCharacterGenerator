using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Seidal : LivingDead
{
    private readonly int age;

    public Seidal()
    {
        age = 20;

        Occurrence = Occurrence.VeryRare;
        Size = Size.Huge; // Size.Small
        PlacesOfOccurrence = TerrainType.CursedLand;

        AttackValue = 55 + age / 10;
        DefenseValue = 65;
        InitiateValue = 15;
        AimValue = 35;

        HealthPoints = age; // + special

        AttacksPerRound = age / 10; // + special

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = (ulong)(30 * age);
        NecrographyDepartment = NecrographyDepartment.BloodDrinkingUndead;
    }

    public override string Name => "Seidal (Vampire Tree)";

    public override string[] Images => ["seidal.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // + special (roots + leaves)

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 1)]; //0

    public override double AttacksPerRound => 1 + age / 10;
}