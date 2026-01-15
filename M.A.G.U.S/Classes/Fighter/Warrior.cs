using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Fighter;

public class Warrior : Class, IClass, IJustFight
{
    public Warrior() : base(1, false) { }

    public Warrior(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._3D6)]
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

    public override int InitiateBaseValue => 9;

    public override int AttackBaseValue => 20;

    public override int DefenseBaseValue => 75;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 11;

    public override int BaseQualificationPoints => 10;

    public override int QualificationPointsModifier => 14;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 7;

    public override int BasePainTolerancePoints => 6;

    public override bool AddCombatModifierOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 160 },
        new() { Level = 2,  MinExperience = 161,   MaxExperience = 320 },
        new() { Level = 3,  MinExperience = 321,   MaxExperience = 640 },
        new() { Level = 4,  MinExperience = 641,   MaxExperience = 1440 },
        new() { Level = 5,  MinExperience = 1441,  MaxExperience = 2800 },
        new() { Level = 6,  MinExperience = 2801,  MaxExperience = 5600 },
        new() { Level = 7,  MinExperience = 5601,  MaxExperience = 10000 },
        new() { Level = 8,  MinExperience = 10001, MaxExperience = 20000 },
        new() { Level = 9,  MinExperience = 20001, MaxExperience = 40000 },
        new() { Level = 10, MinExperience = 40001, MaxExperience = 60000 },
        new() { Level = 11, MinExperience = 60001, MaxExperience = 80000 },
        new() { Level = 12, MinExperience = 80001, MaxExperience = 112000 }
    ];

    public override int ExpPerLevelAfter12 => 31200;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Wier(), new Feenhar(), new Dahr(), new Dracker(), new Draquon(),
        new ForestGiant(), new FrostGiant(), new MountainGiant(), new SwampGiant(), new Gnome(), new CourtGoblin()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new Riding(),
        new Swimming(),
        new Running()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Leadership(level: 6)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Climbing(15),
        new Falling(20),
        new Jumping(10)
    ];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 4;
}
