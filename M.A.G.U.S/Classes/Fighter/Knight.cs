using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Fighter;

public class Knight : Class, IClass, IHateRangedWeapons
{
    public Knight() : base(1, false) { }

    public Knight(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._2D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 5;

    public override int AttackBaseValue => 20;

    public override int DefenseBaseValue => 75;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 12;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 7;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 7;

    public override int BasePainTolerancePoints => 6;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new HalfElf(), new Amund(), new Jann(), new Khal(), new Wier(), new Dracker()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 180 },
        new() { Level = 2,  MinExperience = 181,   MaxExperience = 370 },
        new() { Level = 3,  MinExperience = 371,   MaxExperience = 800 },
        new() { Level = 4,  MinExperience = 801,   MaxExperience = 1650 },
        new() { Level = 5,  MinExperience = 1651,  MaxExperience = 3200 },
        new() { Level = 6,  MinExperience = 3201,  MaxExperience = 6400 },
        new() { Level = 7,  MinExperience = 6401,  MaxExperience = 12000 },
        new() { Level = 8,  MinExperience = 12001, MaxExperience = 25000 },
        new() { Level = 9,  MinExperience = 25001, MaxExperience = 45000 },
        new() { Level = 10, MinExperience = 45001, MaxExperience = 65000 },
        new() { Level = 11, MinExperience = 65001, MaxExperience = 90000 },
        new() { Level = 12, MinExperience = 90001, MaxExperience = 110000 }
    ];

    public override ulong ExpPerLevelAfter12 => 35000;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new HeavyArmorWearing(),
        new ShieldUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponLore(),
        new Leadership(),
        new Etiquette(),
        new Riding(QualificationLevel.Master),
        new LanguageLore(Language.Pyarronian, 4),
        new LanguageLore(Language.Shadonian, 2),
        new LanguageLore(Language.Erven, 2),
        new LanguageLore(Language.Toronian, 2),
        new ReadingAndWriting(),
        new Heraldry()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Heraldry(QualificationLevel.Master, 3),
        new ShieldUse(QualificationLevel.Master, 4),
        new PsiPyarron(level: 4),
        new Healing(level: 4),
        new WeaponUse(QualificationLevel.Master, 5),
        new HeavyArmorWearing(QualificationLevel.Master, 8),
        new Leadership(QualificationLevel.Master, 9),
        new PsiPyarron(QualificationLevel.Master, 12)
    ]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;
}
