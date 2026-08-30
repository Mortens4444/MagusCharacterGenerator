using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Experience;
using MAGUS.GameSystem.FightMode;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Magic;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Races;

namespace MAGUS.Classes.Sorcerer;

public class FireMage : Class, IClass, ILikeMagic
{
    public FireMage() : base(1, false) { }

    public FireMage(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
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

    public override int InitiateBaseValue => 6;

    public override int AttackBaseValue => 17;

    public override int DefenseBaseValue => 72;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 8;

    public override int BaseQualificationPoints => 3;

    public override int QualificationPointsModifier => 5;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 5;

    public override int BasePainTolerancePoints => 4;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Amund(), new Jann(), new Dracker()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 170 },
        new() { Level = 2,  MinExperience = 171,    MaxExperience = 350 },
        new() { Level = 3,  MinExperience = 351,    MaxExperience = 700 },
        new() { Level = 4,  MinExperience = 701,    MaxExperience = 1500 },
        new() { Level = 5,  MinExperience = 1501,   MaxExperience = 3000 },
        new() { Level = 6,  MinExperience = 3001,   MaxExperience = 7000 },
        new() { Level = 7,  MinExperience = 7001,   MaxExperience = 12000 },
        new() { Level = 8,  MinExperience = 12001,  MaxExperience = 22000 },
        new() { Level = 9,  MinExperience = 22001,  MaxExperience = 52500 },
        new() { Level = 10, MinExperience = 52501,  MaxExperience = 85500 },
        new() { Level = 11, MinExperience = 85501,  MaxExperience = 135000 },
        new() { Level = 12, MinExperience = 135001, MaxExperience = 175500 }
    ];

    public override ulong ExpPerLevelAfter12 => 58500;
    
    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new PsiPyarron(QualificationLevel.Master),
        new LanguageLore(Language.Pyarronian, 4),
        new LanguageLore(Language.Toronian, 3),
        new ReadingAndWriting(),
        new Riding(),
        new Sailing()
    ]);

    /// <summary>
    /// Level-5 specialization path (Második Törvénykönyv, "A tűzvarázslók három Útja", p.34-36) -
    /// None until the player picks one via CharacterViewModel.CheckPendingFireMageSpecializationAsync/
    /// Character.ApplyFireMageSpecialization. Drives GetCombatValueModifierForLevel/
    /// GetPainToleranceModifier(level)/FutureQualifications below.
    /// </summary>
    public FireMageSpecialization Specialization { get; set; } = FireMageSpecialization.None;

    /// <summary>Pusztító Tűz Útja (Destructive Fire) raises this from 8 to 9 from level 5 onward - not retroactive to levels 1-4, see the level-summing loop in Character.Combat.cs.</summary>
    public override int GetCombatValueModifierForLevel(int level) =>
        Specialization == FireMageSpecialization.DestructiveFire && level >= 5 ? 9 : CombatValueModifierPerLevel;

    /// <summary>Pusztító Tűz Útja raises this from 1D6+1 to 1D6+3 from level 5 onward.</summary>
    public override int GetPainToleranceModifier(int level) =>
        Specialization == FireMageSpecialization.DestructiveFire && level >= 5 ? DiceThrow._1D6() + 3 : GetPainToleranceModifier();

    /// <summary>Formula counterpart of GetPainToleranceModifier(level), for the manual-roll UI.</summary>
    public override DiceThrowFormula? GetPainToleranceModifierFormula(int level) =>
        Specialization == FireMageSpecialization.DestructiveFire && level >= 5
            ? new DiceThrowFormula { Formula = "1D6", Modifier = 3, HasSpecialTraining = false }
            : GetPainToleranceModifierFormula();

    /// <summary>
    /// Level-gated qualifications granted by whichever of the three Utak was chosen - empty for None
    /// (not yet chosen) and for Sogron (that path converts the character to SogronPriest, whose own
    /// FutureQualifications takes over from here - see Character.ApplyFireMageSpecialization).
    /// Tűzvonás/Tűzgyűjtés (Fény Ösvénye's other flavor abilities) have no mechanical system in this
    /// codebase and aren't modeled.
    /// </summary>
    public override QualificationList FutureQualifications => Specialization switch
    {
        FireMageSpecialization.DestructiveFire => BuildQualifications(
        [
            new WeaponUse(QualificationLevel.Master, 5),
            new HistoryLore(level: 5),
            new Leadership(level: 5),
            new MilitaryFormation(level: 5),
            new MilitaryFormation(QualificationLevel.Master, 7),
            new Leadership(QualificationLevel.Master, 11)
        ]),
        FireMageSpecialization.Light => BuildQualifications(
        [
            new AncientTongueLore(AntientLanguage.OldGodonian, level: 5),
            new HistoryLore(level: 5),
            new LegendLore(level: 5),
            new HistoryLore(QualificationLevel.Master, 8),
            new AncientTongueLore(AntientLanguage.OldGodonian, QualificationLevel.Master, 11)
        ]),
        _ => BuildQualifications([])
    };

    public override PercentQualificationList PercentQualifications => [];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new FireMagic()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 1;

    public override string Name => "Fire Mage";

    public override Deity Deity { get; set; } = Deity.Sogron;
}
