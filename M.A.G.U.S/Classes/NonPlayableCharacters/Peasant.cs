using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Other;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class Peasant : Class, IClass
{
    public Peasant() : base(1, false) { }

    public Peasant(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._3D6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D2)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 1;

    public override int AttackBaseValue => 5;

    public override int DefenseBaseValue => 50;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 4;

    public override int BaseQualificationPoints => 0;

    public override int QualificationPointsModifier => 0;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 3;

    public override int BasePainTolerancePoints => 10;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => false;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new Agriculture(),
        new AnimalBreeding(),
        new PlantGrowing(),
        new WeatherDivination()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications([]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1D2)]
    public override int GetPainToleranceModifier() => DiceThrow._1D2();
}
