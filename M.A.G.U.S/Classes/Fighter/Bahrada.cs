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
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;
using M.A.G.U.S.Things.Weapons.OtherWeapons;
using M.A.G.U.S.Things.Weapons.Spears;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Classes.Fighter;

public class Bahrada : Class, IClass, IJustFight
{
    public Bahrada() : base(1, false) { }

    public Bahrada(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

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

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(12)]
    [SpecialTraining]
    public override int Stamina { get; set; }

    [DiceThrow(ThrowType._1D10)]
    [DiceThrowModifier(10)]
    public override int Health { get; set; }

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(6)]
    public override int Beauty { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Intelligence { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Willpower { get; set; }

    [DiceThrow(ThrowType._3D6)]
    public override int Astral { get; set; }

    [DiceThrow(ThrowType._2D6)]
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

    public override int BaseQualificationPoints => 3;

    public override int QualificationPointsModifier => 6;

    public override int PercentQualificationModifier => 0;

    public override int BaseLifePoints => 8;

    public override int BasePainTolerancePoints => 7;

    public override bool AddCombatModifierOnFirstLevel => false;

    public override bool AddPainToleranceOnFirstLevel => true;

    public override bool AddQualificationPointsOnFirstLevel => true;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Draquon(),
        new ForestGiant(), new MountainGiant(), new SwampGiant(), new CourtGoblin(), new Faun()];

    public override List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,     MaxExperience = 188 },
        new() { Level = 2,  MinExperience = 189,   MaxExperience = 376 },
        new() { Level = 3,  MinExperience = 377,   MaxExperience = 825 },
        new() { Level = 4,  MinExperience = 826,   MaxExperience = 1650 },
        new() { Level = 5,  MinExperience = 1651,  MaxExperience = 3300 },
        new() { Level = 6,  MinExperience = 3301,  MaxExperience = 7250 },
        new() { Level = 7,  MinExperience = 7251,  MaxExperience = 12050 },
        new() { Level = 8,  MinExperience = 12051, MaxExperience = 24000 },
        new() { Level = 9,  MinExperience = 24001, MaxExperience = 48000 },
        new() { Level = 10, MinExperience = 48001, MaxExperience = 68000 },
        new() { Level = 11, MinExperience = 68001, MaxExperience = 93000 },
        new() { Level = 12, MinExperience = 93001, MaxExperience = 130000 }
    ];

    public override ulong ExpPerLevelAfter12 => 40000;

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse(),// { Weapon = new Tahji() },
        new WeaponUse() { Weapon = new Scimitar() },
        new WeaponUse() { Weapon = new Yatagan() },
        new WeaponUse() { Weapon = new Javelin() },
        new ShieldUse(),// { Shield = new JadShield() },
        new Wrestling(),
        new Fistfight(),
        new AnimalLore(),
        new HeavyArmorWearing(),// { Armor = new GladiatorArmor() },
        new Running()
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new WeaponUse(level: 2) { Weapon = new Spear() },
        new WeaponUse(QualificationLevel.Master, 4),
        new WeaponUse(level: 4) { Weapon = new Whip() },
        new WeaponUse(level: 7),
        new AnimalLore(QualificationLevel.Master, 8),
        new TwoHandedCombat(level: 7),
        new Wrestling(level: 3),
        new ShieldUse(QualificationLevel.Master, 6),
        new WeaponBreaking(level: 9)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
        new Falling(30),
        new Jumping(20)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new GladiatorFightAgainstOneEnemy() { Note = "Only against animals" },
        new GladiatorFightInFrontOfAudience()
    ];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;
}
