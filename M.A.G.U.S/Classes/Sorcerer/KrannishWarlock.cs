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
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Underworld;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Sorcerer;

/// <summary>
/// https://www.kalandozok.hu/magus/kalandozok/jatszhatokasztok/magiahasznalo/boszorkanymester/kraniboszorkanymester(mg)kalandozok.pdf
/// </summary>
public class KrannishWarlock : Class, IClass, ILikeMagic
{
    public KrannishWarlock() : base(1, false) { }

    public KrannishWarlock(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Strength { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(8)]
    public override int Quickness { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Dexterity { get; set; }

    [DiceThrow(ThrowType._3D6_2_Times)]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(3)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
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

    public override int InitiateBaseValue => 7;

    public override int AttackBaseValue => 17;

    public override int DefenseBaseValue => 72;

    public override int AimBaseValue => 5;

    public override int CombatValueModifierPerLevel => 7;

    public override int BaseQualificationPoints => 4;

    public override int QualificationPointsModifier => 6;

    public override int PercentQualificationModifier => 10;

    public override int BaseLifePoints => 4;

    public override int BasePainTolerancePoints => 3;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => false;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Amund(), new Jann()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 200 },
        new() { Level = 2,  MinExperience = 201,    MaxExperience = 400 },
        new() { Level = 3,  MinExperience = 401,    MaxExperience = 800 },
        new() { Level = 4,  MinExperience = 801,    MaxExperience = 1600 },
        new() { Level = 5,  MinExperience = 1601,   MaxExperience = 4000 },
        new() { Level = 6,  MinExperience = 4001,   MaxExperience = 8000 },
        new() { Level = 7,  MinExperience = 8001,   MaxExperience = 16000 },
        new() { Level = 8,  MinExperience = 16001,  MaxExperience = 32000 },
        new() { Level = 9,  MinExperience = 32001,  MaxExperience = 59000 },
        new() { Level = 10, MinExperience = 59001,  MaxExperience = 90500 },
        new() { Level = 11, MinExperience = 90501,  MaxExperience = 140000 },
        new() { Level = 12, MinExperience = 140001, MaxExperience = 190000 }
    ];

    public override ulong ExpPerLevelAfter12 => 55000;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new PsiKranic(QualificationLevel.Master),
        new ReadingAndWriting(),
        new PoisoningAndNeutralization(),
        new CamouflageOrDisguise(),
        new LanguageLore(Language.Krannish, 3),
        new Alchemy(),
        new AncientTongueLore(AntientLanguage.Aquir),
        new Etiquette(), //Krannish

		//new Cluture(QualificationLevel.Master) // Order
		//new Helyismeret 60%
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new Craft(Profession.TattoMaker, level: 2),
        new ReligionLore(level: 2),
        new Herbalism(level: 3),
        new Alchemy(QualificationLevel.Master, 3),
        new Etiquette(QualificationLevel.Master, 4), //Krannish
        new PoisoningAndNeutralization(QualificationLevel.Master, 4),
        new Craft(Profession.TattoMaker, QualificationLevel.Master, 5),
        new Backstab(level: 5),
        new Herbalism(QualificationLevel.Master, 6),
        new AncientTongueLore(AntientLanguage.Aquir, QualificationLevel.Master, 6),
        new RunicMagic(level: 7),
        new Demonology(level: 8)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Sneaking(15),
        new Hiding(10)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Warlockry()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 1;

    public override string Name => "Krannish Mage";
}
