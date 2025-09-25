using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Classes;

public abstract class Class(byte level) : IClass
{
    protected const string _1K6_Plus_12_Plus_SpecialTraining = "1K6 + 12 + Special training";

    protected readonly DiceThrow DiceThrow = new();

    public virtual string ClassName => GetType().Name;

    public string Name { get; set; } = String.Empty;

    public byte Level { get; set; } = level;

    public abstract short Gold { get; }

    public abstract byte Bravery { get; }

    public abstract byte Erudition { get; }

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

    public abstract short Strength { get; }

    public abstract short Speed { get; }

    public abstract short Dexterity { get; }

    public abstract short Stamina { get; }

    public abstract short Health { get; }

    public abstract short Beauty { get; }

    public abstract short Intelligence { get; }

    public abstract short Willpower { get; }

    public abstract short Astral { get; }

    public abstract byte GetPainToleranceModifier();
}
