using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Other;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.NonPlayableCharacters;

public class JahPriest : Class, IClass
{
    public JahPriest() : base(1, false) { }

    public JahPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

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

    public override IRace[] AllowedRaces => [new Human(), new Jann()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 160 },
        new() { Level = 2,  MinExperience = 161,    MaxExperience = 330 },
        new() { Level = 3,  MinExperience = 331,    MaxExperience = 660 },
        new() { Level = 4,  MinExperience = 661,    MaxExperience = 1300 },
        new() { Level = 5,  MinExperience = 1301,   MaxExperience = 2600 },
        new() { Level = 6,  MinExperience = 2601,   MaxExperience = 5000 },
        new() { Level = 7,  MinExperience = 5001,   MaxExperience = 9000 },
        new() { Level = 8,  MinExperience = 9001,   MaxExperience = 23000 },
        new() { Level = 9,  MinExperience = 23001,  MaxExperience = 50000 },
        new() { Level = 10, MinExperience = 50001,  MaxExperience = 90000 },
        new() { Level = 11, MinExperience = 90001,  MaxExperience = 130000 },
        new() { Level = 12, MinExperience = 130001, MaxExperience = 165000 }
    ];

    public override ulong ExpPerLevelAfter12 => 50000;

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

    public override string Name => "Priest of Jah";

    [DiceThrow(ThrowType._1D2)]
    public override int GetPainToleranceModifier() => DiceThrow._1D2();
}
