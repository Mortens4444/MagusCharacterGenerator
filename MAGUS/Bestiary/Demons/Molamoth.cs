using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Models;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Demons;

public sealed class Molamoth : Creature
{
    public Molamoth()
    {
        Occurrence = Occurrence.Summoned;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Size = Size.Small;

        AttackValue = 55;
        DefenseValue = 95;
        InitiateValue = 25;

        HealthPoints = 8;
        PainTolerancePoints = 45;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = int.MaxValue;
        MentalMagicResistance = int.MaxValue;

        Psi = new PsiPyarron(QualificationLevel.Master);
        PsiPoints = 37; // 8th level

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = 500;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Claw (poison)", ThrowType._1D3), AttackValue)
        ];
    }

    public override string Name => "Molamoth (The Servant)";

    public override string[] Images => ["molamoth.png"];

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3(); // + poison or weapon

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];
}