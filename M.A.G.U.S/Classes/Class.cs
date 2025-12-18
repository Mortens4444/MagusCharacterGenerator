using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes;

public abstract class Class : IClass
{
    protected const string _1D6_Plus_12_Plus_SpecialTraining = "1D6 + 12 + Special training";

    protected readonly DiceThrow DiceThrow = new();

    protected Class(int level)
    {
        Level = level;
    }

    protected void GenerateSkills()
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

    public abstract int Gold { get; set; }

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

    public abstract bool AddFightValueOnFirstLevel { get; }

    public abstract bool AddPainToleranceOnFirstLevel { get; }

    public abstract bool AddQualificationPointsOnFirstLevel { get; }

    public abstract QualificationList Qualifications { get; }

    public abstract QualificationList FutureQualifications { get; }

    public abstract List<PercentQualification> PercentQualifications { get; }

    public abstract SpecialQualificationList SpecialQualifications { get; }

    public abstract int Strength { get; set; }

    public abstract int Quickness { get; set; }

    public abstract int Dexterity { get; set; }

    public abstract int Stamina { get; set; }

    public abstract int Health { get; set; }

    public abstract int Beauty { get; set; }

    public abstract int Intelligence { get; set; }

    public abstract int Willpower { get; set; }

    public abstract int Astral { get; set; }

    public abstract int Bravery { get; set; }

    public abstract int Erudition { get; set; }

    public abstract int Detection { get; set; }

    public int AstralMagicResistance { get; }

    public int MentalMagicResistance { get; }

    public ulong ExperiencePoints { get; }

    public virtual Alignment Alignment => Alignment.Order;

    public virtual IRace[] AllowedRaces => [];

    public abstract int GetPainToleranceModifier();

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
}
