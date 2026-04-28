using M.A.G.U.S.Enums;
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
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Classes.Fighter;

public class Duelist : Class, IClass, IJustFight
{
    public Duelist() : base(1, false) { }

    public Duelist(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    [SpecialTraining]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
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

    public override int CombatValueModifierPerLevel => 12;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 6;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 5;

    public override int BasePainTolerancePoints => 5;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => false;

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 165 },
        new() { Level = 2,  MinExperience = 166,   MaxExperience = 330 },
        new() { Level = 3,  MinExperience = 331,   MaxExperience = 660 },
        new() { Level = 4,  MinExperience = 661,   MaxExperience = 1485 },
        new() { Level = 5,  MinExperience = 1486,  MaxExperience = 2900 },
        new() { Level = 6,  MinExperience = 2901,  MaxExperience = 5800 },
        new() { Level = 7,  MinExperience = 5801,  MaxExperience = 11000 },
        new() { Level = 8,  MinExperience = 11001, MaxExperience = 22000 },
        new() { Level = 9,  MinExperience = 22001, MaxExperience = 45000 },
        new() { Level = 10, MinExperience = 45001, MaxExperience = 67500 },
        new() { Level = 11, MinExperience = 67001, MaxExperience = 90000 },
        new() { Level = 12, MinExperience = 90001, MaxExperience = 136000 }
    ];

    public override ulong ExpPerLevelAfter12 => 31200;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Wier(), new Feenhar(), new Dahr(), new Dracker(), new Draquon(),
        new ForestGiant(), new FrostGiant(), new MountainGiant(), new SwampGiant(), new Gnome(), new CourtGoblin(), new GhoRagg(), new MutantOrc(), new CwyvehKah()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse() { Weapon = new Rapier() },
        new WeaponLore() { /* Weapon = new Rapier() */ },
        new Disarmament() { /* Weapon = new Rapier() */ },
        new LanguageLore(Language.Shadonian, 6),
        new LanguageLore(Language.Pyarronian, 5),
        new LanguageLore(Language.Erven, 5),
        new BlindFighting(),
        new ReadingAndWriting(),
        new PsiPyarron(),
        new LegendLore(),
        new ReligionLore(),
        new HistoryLore(),
        new Heraldry(QualificationLevel.Master),
        new Riding(),
        new SexualCulture(),
        new SingingAndMakingMusic(),
        new Swimming(),
        new Etiquette(QualificationLevel.Master),
        new Dancing(QualificationLevel.Master) // Court style
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new WeaponUse(QualificationLevel.Master, 2) { Weapon = new Rapier() },
        new Disarmament(QualificationLevel.Master, 3) { /* Weapon = new Rapier() */ },
        new BlindFighting(QualificationLevel.Master, 4) { /* Weapon = new Rapier() */ },
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        // Only for Aleggheri style
        new Jumping(20) // + 3% per level
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new FatalStab(),
        new MakersMark(),
        new Provocation()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 3;
}
