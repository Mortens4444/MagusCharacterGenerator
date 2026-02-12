using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class Guard : Class, IClass
{
    public Guard() : base(1, false) { }

    public Guard(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

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

    [DiceThrow(ThrowType._1D5)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 3;

    public override int AttackBaseValue => 15;

    public override int DefenseBaseValue => 65;

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
        new WeaponUse(),
        new WeaponUse(),
        new HeavyArmorWearing(),
        new ShieldUse()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications([]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1D5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D5();
}
