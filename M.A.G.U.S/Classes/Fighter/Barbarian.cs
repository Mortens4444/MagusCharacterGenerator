using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Fighter;

public class Barbarian : Class, IClass, IJustFight
{
    //A korg Teljes ME-je(Asztrális és Mentális is) első szinten 15 és minden további szinten 4 - el nő.
    public Barbarian() : base(1, false) { }

    public Barbarian(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    [SpecialTraining]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    [SpecialTraining]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(-1)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 10;

    public override int AttackBaseValue => 26;

    public override int DefenseBaseValue => 70;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 12;

    public override int BaseQualificationPoints => 7;

    public override int QualificationPointsModifier => 10;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 8;

    public override int BasePainTolerancePoints => 7;

    public override bool AddCombatModifierOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 150 },
        new() { Level = 2,  MinExperience = 151,   MaxExperience = 310 },
        new() { Level = 3,  MinExperience = 311,   MaxExperience = 630 },
        new() { Level = 4,  MinExperience = 631,   MaxExperience = 1300 },
        new() { Level = 5,  MinExperience = 1301,  MaxExperience = 2700 },
        new() { Level = 6,  MinExperience = 2701,  MaxExperience = 5400 },
        new() { Level = 7,  MinExperience = 5401,  MaxExperience = 10800 },
        new() { Level = 8,  MinExperience = 10801, MaxExperience = 21600 },
        new() { Level = 9,  MinExperience = 21601, MaxExperience = 42000 },
        new() { Level = 10, MinExperience = 42001, MaxExperience = 65000 },
        new() { Level = 11, MinExperience = 65001, MaxExperience = 90000 },
        new() { Level = 12, MinExperience = 90001, MaxExperience = 120000 }
    ];

    public override ulong ExpPerLevelAfter12 => 31200;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Wier(), new Feenhar(), new Dahr(), new Dracker(), new Draquon(),
        new ForestGiant(), new FrostGiant(), new MountainGiant(), new SwampGiant(), new Gnome(), new CourtGoblin(), new GhoRagg(), new MutantOrc(), new CwyvehKah()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new Wrestling(),
        new Fistfight(),
        new WeaponBreaking(),
        new WeatherDivination(),
        new ForestSurvival(QualificationLevel.Master),
        new HuntingAndFishing(QualificationLevel.Master),
        new Running()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Falling(40),
        new Jumping(25)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ExtraMagicResistanceOnLevelUp(4)
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;
}
