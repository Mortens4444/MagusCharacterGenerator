using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Classes;

public abstract class Class : IClass
{
    protected const string _1K6_Plus_12_Plus_SpecialTraining = "1K6 + 12 + Special training";

    protected readonly DiceThrow DiceThrow = new();

    protected Class(byte level)
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

    public byte Level { get; set; }

    public abstract byte Gold { get; set; }

    public abstract byte InitiatingBaseValue { get; }

    public abstract byte AttackingBaseValue { get; }

    public abstract byte DefendingBaseValue { get; }

    public abstract byte AimingBaseValue { get; }

    public abstract byte FightValueModifier { get; }

    public abstract byte BaseQualificationPoints { get; }

    public abstract byte QualificationPointsModifier { get; }

    public abstract byte PercentQualificationModifier { get; }

    public abstract byte BaseLifePoints { get; }

    public abstract byte BasePainTolerancePoints { get; }

    public abstract bool AddFightValueOnFirstLevel { get; }

    public abstract bool AddPainToleranceOnFirstLevel { get; }

    public abstract bool AddQualificationPointsOnFirstLevel { get; }

    public abstract QualificationList Qualifications { get; }

    public abstract QualificationList FutureQualifications { get; }

    public abstract List<PercentQualification> PercentQualifications { get; }

    public abstract SpecialQualificationList SpecialQualifications { get; }

    public abstract sbyte Strength { get; set; }

    public abstract sbyte Quickness { get; set; }

    public abstract sbyte Dexterity { get; set; }

    public abstract sbyte Stamina { get; set; }

    public abstract sbyte Health { get; set; }

    public abstract sbyte Beauty { get; set; }

    public abstract sbyte Intelligence { get; set; }

    public abstract sbyte Willpower { get; set; }

    public abstract sbyte Astral { get; set; }

    public abstract sbyte Bravery { get; set; }

    public abstract sbyte Erudition { get; set; }

    public abstract sbyte Detection { get; set; }

    public byte AstralMagicResistance { get; }

    public byte MentalMagicResistance { get; }

    public ulong ExperiencePoints { get; }

    public abstract byte GetPainToleranceModifier();

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
