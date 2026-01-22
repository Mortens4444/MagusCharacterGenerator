using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Experience;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Races;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Classes;

public abstract class Class : IClass, IHaveImage
{
    protected const string _1D6_Plus_12_Plus_SpecialTraining = "1D6 + 12 + Special training";

    protected readonly DiceThrow DiceThrow = new();

    protected Class(int level, bool autoGenerateSkills)
    {
        Level = level;
        if (autoGenerateSkills)
        {
            GenerateSkills();
        }
    }

    private void GenerateSkills()
    {
        string[] skillNames = [ nameof(Strength), nameof(Quickness), nameof(Dexterity), nameof(Stamina), nameof(Health), nameof(Beauty),
            nameof(Intelligence), nameof(Willpower), nameof(Astral), nameof(Bravery), nameof(Erudition), nameof(Detection), nameof(Gold) ];

        var derivedType = GetType();
        foreach (var skillName in skillNames)
        {
            var propertyInfo = derivedType.GetProperty(skillName);
            if (propertyInfo != null)
            {
                var diceThrowAttribute = (DiceThrowAttribute?)propertyInfo.GetCustomAttributes(typeof(DiceThrowAttribute), true).FirstOrDefault();
                var diceThrowModifierAttr = (DiceThrowModifierAttribute?)propertyInfo.GetCustomAttributes(typeof(DiceThrowModifierAttribute), true).FirstOrDefault();
                var specialTrainingAttr = (SpecialTrainingAttribute?)propertyInfo.GetCustomAttributes(typeof(SpecialTrainingAttribute), true).FirstOrDefault();
                var value = DiceThrow.Throw(diceThrowAttribute, diceThrowModifierAttr, specialTrainingAttr);
                if (propertyInfo.SetMethod != null)
                {
                    var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                    propertyInfo.SetValue(this, convertedValue);
                }
                else
                {
                    throw new InvalidOperationException($"No setter found for {derivedType.Name}.{skillName}");
                }
            }
        }
    }

    public virtual string Name => GetType().Name;

    public override string ToString() => Name;

    public int Level { get; set; }

    public abstract int InitiateBaseValue { get; }

    public abstract int AttackBaseValue { get; }

    public abstract int DefenseBaseValue { get; }

    public abstract int AimBaseValue { get; }

    public abstract int CombatValueModifierPerLevel { get; }

    public abstract int BaseQualificationPoints { get; }

    public abstract int QualificationPointsModifier { get; }

    public abstract int PercentQualificationModifier { get; }

    public abstract int BaseLifePoints { get; }

    public abstract int BasePainTolerancePoints { get; }

    public abstract bool AddCombatModifierOnFirstLevel { get; }

    public abstract bool AddPainToleranceOnFirstLevel { get; }

    public abstract bool AddQualificationPointsOnFirstLevel { get; }

    public abstract QualificationList Qualifications { get; }

    public abstract QualificationList FutureQualifications { get; }

    public abstract PercentQualificationList PercentQualifications { get; }

    public abstract SpecialQualificationList SpecialQualifications { get; }

    [OrderAttibute(1)]
    public abstract int Strength { get; set; }

    [OrderAttibute(2)]
    public abstract int Stamina { get; set; }

    [OrderAttibute(3)]
    public abstract int Quickness { get; set; }

    [OrderAttibute(4)]
    public abstract int Dexterity { get; set; }

    [OrderAttibute(5)]
    public abstract int Health { get; set; }

    [OrderAttibute(6)]
    public abstract int Beauty { get; set; }

    [OrderAttibute(7)]
    public abstract int Intelligence { get; set; }

    [OrderAttibute(8)]
    public abstract int Willpower { get; set; }

    [OrderAttibute(9)]
    public abstract int Astral { get; set; }

    [OrderAttibute(10)]
    public abstract int Bravery { get; set; }

    [OrderAttibute(10)]
    public abstract int Erudition { get; set; }

    [OrderAttibute(11)]
    public abstract int Detection { get; set; }

    [OrderAttibute(12)]
    public abstract int Gold { get; set; }

    public int AstralMagicResistance { get; }

    public int MentalMagicResistance { get; }

    public ulong ExperiencePoints { get; set; }

    public virtual Alignment Alignment => Alignment.Order;

    public virtual IRace[] AllowedRaces => [];

    public virtual List<LevelRequirement> ExperienceLevels =>
    [
        new() { Level = 1,  MinExperience = 0,      MaxExperience = 190 },
            new() { Level = 2,  MinExperience = 191,    MaxExperience = 400 },
            new() { Level = 3,  MinExperience = 401,    MaxExperience = 900 },
            new() { Level = 4,  MinExperience = 901,    MaxExperience = 1800 },
            new() { Level = 5,  MinExperience = 1801,   MaxExperience = 3500 },
            new() { Level = 6,  MinExperience = 3501,   MaxExperience = 7500 },
            new() { Level = 7,  MinExperience = 7501,   MaxExperience = 15000 },
            new() { Level = 8,  MinExperience = 15001,  MaxExperience = 30000 },
            new() { Level = 9,  MinExperience = 30001,  MaxExperience = 60000 },
            new() { Level = 10, MinExperience = 60001,  MaxExperience = 110000 },
            new() { Level = 11, MinExperience = 110001, MaxExperience = 160000 },
            new() { Level = 12, MinExperience = 160001, MaxExperience = 220000 }
    ];

    public virtual ulong ExpPerLevelAfter12 => 60000;

    public virtual string[] Images => [$"{Name.ToImageName()}.png"];

    public virtual string DefaultImage => Images.Length > 0 ? Images[0] : String.Empty;

    public virtual string RandomImage => Images.Length > 1 ? Images[RandomProvider.GetSecureRandomInt(0, Images.Length)] : DefaultImage;

    public abstract int GetPainToleranceModifier();

    public DiceThrowFormula? GetPainToleranceModifierFormula()
    {
        var customAttributes = GetType().GetMethod(nameof(GetPainToleranceModifier))?.GetCustomAttributes(false);
        return customAttributes.GetDiceThrowFormula();
    }

    protected QualificationList BuildQualifications(IEnumerable<Qualification> qualifications)
    {
        var result = new QualificationList();

        foreach (var qualification in qualifications)
        {
            if (qualification is IPsi)
            {
                if (Intelligence > 11 && Willpower > 11 && Astral > 11)
                {
                    result.Add(qualification);
                }
            }
            else
            {
                result.Add(qualification);
            }
        }

        return result;
    }

    public ulong GetExperiencePointsForLevel(int level)
    {
        var requirement = ExperienceLevels.FirstOrDefault(l => l.Level == level);
        if (requirement != null)
        {
            return requirement.MinExperience;
        }
        var level12Max = ExperienceLevels.Last().MaxExperience;
        if (level > 12)
        {
            var extraLevels = (ulong)(level - 12);
            return level12Max + (extraLevels * ExpPerLevelAfter12);
        }
        return 0;
    }

    public int GetLevelByExperiencePoints(ulong experiencePoints)
    {
        var requirement = ExperienceLevels.FirstOrDefault(l => experiencePoints >= l.MinExperience && experiencePoints <= l.MaxExperience);
        if (requirement != null)
        {
            return requirement.Level;
        }

        var level12Max = ExperienceLevels.Last().MaxExperience;
        if (experiencePoints > level12Max)
        {
            var extraExp = experiencePoints - level12Max;
            return 12 + (int)(extraExp / ExpPerLevelAfter12);
        }

        return 1;
    }
}
