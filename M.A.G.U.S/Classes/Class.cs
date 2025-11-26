using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Classes;

public abstract class Class(byte level) : IClass
{
    protected const string _1K6_Plus_12_Plus_SpecialTraining = "1K6 + 12 + Special training";

    protected readonly DiceThrow DiceThrow = new();

    public virtual string Name => GetType().Name;

    public byte Level { get; set; } = level;

    public abstract byte Gold { get; }

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

    public abstract sbyte Strength { get; }

    public abstract sbyte Quickness { get; }

    public abstract sbyte Dexterity { get; }

    public abstract sbyte Stamina { get; }

    public abstract sbyte Health { get; }

    public abstract sbyte Beauty { get; }

    public abstract sbyte Intelligence { get; }

    public abstract sbyte Willpower { get; }

    public abstract sbyte Astral { get; }

    public abstract sbyte Bravery { get; }

    public abstract sbyte Erudition { get; }

    public abstract sbyte Detection { get; }

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
