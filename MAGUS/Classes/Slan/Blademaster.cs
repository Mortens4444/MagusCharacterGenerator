using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Experience;
using MAGUS.GameSystem.FightMode;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Percentages;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Qualifications.Specialities;
using MAGUS.Races;

namespace MAGUS.Classes.Slan;

public class Blademaster : Class, IClass, IJustFight
{
    public Blademaster() : base(1, false) { }

    public Blademaster(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 10;

    public override int AttackBaseValue => 20;

    public override int DefenseBaseValue => 75;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 8;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 5;

    public override int PercentQualificationModifier => 18;

    public override int BaseLifePoints => 4;

    public override int BasePainTolerancePoints => 8;

    public override bool AddCombatModifierOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new HalfElf(), new Amund(), new Jann(), new Dahr(), new Dracker()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 200 },
        new() { Level = 2,  MinExperience = 201,    MaxExperience = 400 },
        new() { Level = 3,  MinExperience = 401,    MaxExperience = 925 },
        new() { Level = 4,  MinExperience = 926,    MaxExperience = 1900 },
        new() { Level = 5,  MinExperience = 1901,   MaxExperience = 4000 },
        new() { Level = 6,  MinExperience = 4001,   MaxExperience = 8250 },
        new() { Level = 7,  MinExperience = 8251,   MaxExperience = 15500 },
        new() { Level = 8,  MinExperience = 15501,  MaxExperience = 31000 },
        new() { Level = 9,  MinExperience = 31001,  MaxExperience = 62500 },
        new() { Level = 10, MinExperience = 62501,  MaxExperience = 115000 },
        new() { Level = 11, MinExperience = 115001, MaxExperience = 165000 },
        new() { Level = 12, MinExperience = 165001, MaxExperience = 230000 }
    ];

    public override ulong ExpPerLevelAfter12 => 62000;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new PsiSlanWay(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponBreaking(),
        new Fistfight(),
        new Wrestling(),
        new BlindFighting(),
        new Leadership(),
        new Etiquette(),
        new Riding(),
        new Swimming(),
        new Running()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Riding(QualificationLevel.Master, 3),
        new WeaponBreaking(QualificationLevel.Master, 4),
        new BlindFighting(QualificationLevel.Master, 5),
        new WeaponUse(QualificationLevel.Master, 5)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Climbing(10),
        new Falling(20),
        new Jumping(10)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new SlanDodgeAgainstRangedAttacks(),
        new SwordFighterMagicSword()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;
}
