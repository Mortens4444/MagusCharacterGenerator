using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Demons;

public sealed class Morquor : Creature
{
    public Morquor()
    {
        Occurrence = Occurrence.Summoned;
        PlacesOfOccurrence = TerrainType.Anywhere;
        Size = Size.Huge;

        AttackValue = 75;
        DefenseValue = 100;
        InitiateValue = 30;

        AttacksPerRound = 4;

        HealthPoints = 18;
        PainTolerancePoints = 66;

        PoisonResistance = Int32.MaxValue;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;

        Psi = new PsiPyarron(QualificationLevel.Master);
        PsiPoints = 53; // 12th level

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.ChaosDeath;

        ExperiencePoints = 10000;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Fire touch (left 1)", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Fire touch (left 2)", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Fire touch (right 1)", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Fire touch (right 2)", ThrowType._1D6), AttackValue)
        ];
    }

    public override string Name => "Morquor (The Firebreather)";

    public override string[] Images => ["morquor.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];
}
