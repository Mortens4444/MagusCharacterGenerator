using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Sorcerer;

public class Wizard : Class, IClass, ILikeMagic
{
    public Wizard() : base(1, false) { }

    public Wizard(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._3D6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
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

    public override int InitiateBaseValue => 2;

    public override int AttackBaseValue => 15;

    public override int DefenseBaseValue => 70;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 4;

    public override int BaseQualificationPoints => 7;

    public override int QualificationPointsModifier => 7;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 3;

    public override int BasePainTolerancePoints => 2;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new Amund(), new Jann(), new Wier(), new Dahr(), new Gnome()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 230 },
        new() { Level = 2,  MinExperience = 231,    MaxExperience = 500 },
        new() { Level = 3,  MinExperience = 501,    MaxExperience = 1000 },
        new() { Level = 4,  MinExperience = 1001,   MaxExperience = 2200 },
        new() { Level = 5,  MinExperience = 2201,   MaxExperience = 5000 },
        new() { Level = 6,  MinExperience = 5001,   MaxExperience = 10000 },
        new() { Level = 7,  MinExperience = 10001,  MaxExperience = 18000 },
        new() { Level = 8,  MinExperience = 18001,  MaxExperience = 35000 },
        new() { Level = 9,  MinExperience = 35001,  MaxExperience = 70000 },
        new() { Level = 10, MinExperience = 70001,  MaxExperience = 150000 },
        new() { Level = 11, MinExperience = 150001, MaxExperience = 200000 },
        new() { Level = 12, MinExperience = 200001, MaxExperience = 300000 }
    ];

    public override ulong ExpPerLevelAfter12 => 80000;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new PsiKyrMethod(),
        new LanguageLore(Language.Pyarronian, 5),
        new LanguageLore(Language.Doranian, 4),
        new ReadingAndWriting(),
        new Alchemy(),
        new AncientTongueLore(),
        new Healing(),
        new Physiology(),
        new LegendLore(),
        new HistoryLore(),
        new RunicMagic()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Herbalism(level: 4),
        new Alchemy(QualificationLevel.Master, 6),
        new RunicMagic(QualificationLevel.Master, 6),
        new LegendLore(QualificationLevel.Master, 7),
        new HistoryLore(QualificationLevel.Master, 8)
    ]);

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Wizardry()
    ];

    [DiceThrow(ThrowType._1D6)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6();
}
