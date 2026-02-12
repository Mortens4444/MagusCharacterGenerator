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
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Sorcerer;

public class Shaman : Class, IClass, ILikeMagic
{
    public Shaman() : base(1, false) { }

    public Shaman(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._2D6)] // 2 Times
    [DiceThrowModifier(6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(6)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D6)]
    public override int Gold { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Bravery { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(8)]
    public override int Erudition { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Detection { get; set; }

    public override int InitiateBaseValue => 4;

    public override int AttackBaseValue => 15;

    public override int DefenseBaseValue => 70;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 5;

    public override int BaseQualificationPoints => 3;

    public override int QualificationPointsModifier => 4;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 4;

    public override int BasePainTolerancePoints => 6;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new CourtOrc(), new Wier(), new CourtGoblin()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 165 },
        new() { Level = 2,  MinExperience = 166,    MaxExperience = 340 },
        new() { Level = 3,  MinExperience = 341,    MaxExperience = 690 },
        new() { Level = 4,  MinExperience = 691,    MaxExperience = 1450 },
        new() { Level = 5,  MinExperience = 1451,   MaxExperience = 3500 },
        new() { Level = 6,  MinExperience = 3501,   MaxExperience = 7650 },
        new() { Level = 7,  MinExperience = 7651,   MaxExperience = 13800 },
        new() { Level = 8,  MinExperience = 13801,  MaxExperience = 27000 },
        new() { Level = 9,  MinExperience = 27001,  MaxExperience = 50000 },
        new() { Level = 10, MinExperience = 50001,  MaxExperience = 97500 },
        new() { Level = 11, MinExperience = 97501,  MaxExperience = 147000 },
        new() { Level = 12, MinExperience = 147001, MaxExperience = 192000 }
    ];

    public override ulong ExpPerLevelAfter12 => 55000;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new Riding(),
        new Herbalism(QualificationLevel.Master),
        new WeatherDivination(),
        new Healing(QualificationLevel.Master),
        new PoisoningAndNeutralization(),
        new HuntingAndFishing(),
        new ForestSurvival(),
        new SteppeSurvival(),
        new SingingAndMakingMusic(),
        new ReligionLore(QualificationLevel.Master), // Own
        new LegendLore(), // Own
        new TortureResistance(QualificationLevel.Master)
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Onomatopoeia(level: 2),
        new WeatherDivination(QualificationLevel.Master, 3),
        new LegendLore(QualificationLevel.Master, 4), // Own
        //new Astrology(level: 5),
        new HistoryLore(level: 5), // Own
        new PoisoningAndNeutralization(QualificationLevel.Master, 5),
        new Demonology(),
        new Onomatopoeia(QualificationLevel.Master, 7),
        new Demonology(QualificationLevel.Master, 9),
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Divination(Level * 8)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new SamanMagic(Willpower),
        new DetectHighAstral(20),
        new DetectHighIntelligence(20),
        new DetectHighWillpower(20),
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 2;
}
