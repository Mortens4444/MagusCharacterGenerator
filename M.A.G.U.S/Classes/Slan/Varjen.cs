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

namespace M.A.G.U.S.Classes.Slan;

public class Varjen : Class, IClass, IJustFight
{
    public Varjen() : base(1, false) { }

    public Varjen(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._1D3)]
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

    public override int AimBaseValue => 10;

    public override int CombatValueModifierPerLevel => 12;

    public override int BaseQualificationPoints => 7;

    public override int QualificationPointsModifier => 12;

    public override int PercentQualificationModifier => 40;

    public override int BaseLifePoints => 5;

    public override int BasePainTolerancePoints => 7;

    public override bool AddCombatModifierOnFirstLevel => true;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new HalfElf(), new Amund(), new Jann(), new Dahr()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 220 },
        new() { Level = 2,  MinExperience = 221,    MaxExperience = 442 },
        new() { Level = 3,  MinExperience = 443,    MaxExperience = 950 },
        new() { Level = 4,  MinExperience = 951,    MaxExperience = 2000 },
        new() { Level = 5,  MinExperience = 2001,   MaxExperience = 4500 },
        new() { Level = 6,  MinExperience = 4501,   MaxExperience = 9000 },
        new() { Level = 7,  MinExperience = 9001,   MaxExperience = 16000 },
        new() { Level = 8,  MinExperience = 16001,  MaxExperience = 32000 },
        new() { Level = 9,  MinExperience = 32001,  MaxExperience = 65000 },
        new() { Level = 10, MinExperience = 65001,  MaxExperience = 120000 },
        new() { Level = 11, MinExperience = 120001, MaxExperience = 170000 },
        new() { Level = 12, MinExperience = 170001, MaxExperience = 240000 }
    ];

    public override ulong ExpPerLevelAfter12 => 65000;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new PsiSlanWay(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponThrowing(),
        new WeaponBreaking() { Note = "With saik" },
        new TwoHandedCombat(QualificationLevel.Master),
        new ExtraAttack(QualificationLevel.Master) { Note = "With foot" },
        new Torture(),
        new Riding(QualificationLevel.Master),
        new Swimming(),
        new Alchemy(),
        new Physiology(),
        new Leadership() { Note = "With saik" },
        new WeatherDivination(),
        new LanguageLore(4) { Language = Language.Pyarronian },
        new ReadingAndWriting(),
        new Cartography(),

    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Sneaking(25),
        new Hiding(20),
        new Jumping(15),
        new Falling(10),
        new LockPicking(5)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new VarjenStyle(),
        new SlanDodgeAgainstRangedAttacks(),
        new BareHandFighterRunning(),
        new BareHandFighterMagicHand()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;
}
