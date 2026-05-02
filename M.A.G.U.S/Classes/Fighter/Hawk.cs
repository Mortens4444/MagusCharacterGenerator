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
using M.A.G.U.S.Qualifications.Other;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Races;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Animals;
using M.A.G.U.S.Things.Shields;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.Spears;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Classes.Fighter;

public class Hawk : Class, IClass, IJustFight
{
    private readonly List<Weapon> weapons =
    [
        RandomProvider.GetSecureRandomInt(0, 2) == 0 ? new Saber() : new Longsword(),
        RandomProvider.GetSecureRandomInt(0, 2) == 0 ? new Spear() : new BattleAxe(),
        new Javelin(),
        new NomadBow()
    ];

    private List<Thing> BuildStartingEquipment()
    {
        return
        [
            ..weapons,
            new HorseLightWar(ThrowType._1D10_Plus_9),
            new SmallShield()
        ];
    }

    public Hawk() : base(1, false) { }

    public Hawk(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

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

    public override int AimBaseValue => 25;

    public override int CombatValueModifierPerLevel => 11;

    public override int BaseQualificationPoints => 5;

    public override int QualificationPointsModifier => 7;

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

    public override List<Thing> StartingEquipment => BuildStartingEquipment();

    public override string[] Images => ["yllinor_hawk.png"];

    public override ulong ExpPerLevelAfter12 => 31200;

    public override IRace[] AllowedRaces => [new Human(), new Elf(), new HalfElf(), new Dwarf(), new CourtOrc(), new Amund(), new Jann(), new Khal(), new Wier(), new Feenhar(), new Dahr(), new Dracker(), new Draquon(),
        new ForestGiant(), new FrostGiant(), new MountainGiant(), new SwampGiant(), new Gnome(), new CourtGoblin(), new GhoRagg(), new MutantOrc(), new CwyvehKah()];

    public override QualificationList Qualifications => BuildQualifications(
    [
        new WeaponUse() { Weapon = weapons[0] },
        new WeaponUse() { Weapon = weapons[1] },
        new WeaponUse() { Weapon = weapons[2] },
        new WeaponUse(QualificationLevel.Master) { Weapon = weapons[3] },

        new Riding(QualificationLevel.Master),
        new AnimalTraining(QualificationLevel.Master) { Note = "Horse only" },
        new Swimming(),
        new Running(),
        new Healing(),
        new Herbalism(),
        new Bowyer(QualificationLevel.Master),
        new HorseTrader(QualificationLevel.Master)
    ]);

    public override QualificationList FutureQualifications => BuildQualifications(
    [
        new MountedArchery(QualificationLevel.Master, level: 3),
        new Aiming(QualificationLevel.Master, level: 4)
    ]);

    public override PercentQualificationList PercentQualifications =>
    [
    ];

    public override SpecialQualificationList SpecialQualifications => [];

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(4)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 4;
}
