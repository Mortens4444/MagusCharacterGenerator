using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Hekator : LivingDead
{
    public Hekator()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 20;
        DefenseValue = 50;
        InitiateValue = 10;

        MinHealthPoints = 1;
        MaxHealthPoints = 30;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 50;
        NecrographyDepartment = NecrographyDepartment.WanderingCorpse;
    }

    public override string Name => "Wandering Soul (Hekator)";

    public override string[] Images => ["hekator.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 20)];
}