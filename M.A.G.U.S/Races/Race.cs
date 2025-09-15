using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Races;

public abstract class Race : IRace
{
    protected readonly DiceThrow DiceThrow = new();

    public virtual string Name => GetType().Name;

    public virtual QualificationList Qualifications => [];

    public virtual List<PercentQualification> PercentQualifications => [];

    public virtual SpecialQualificationList SpecialQualifications => [];

    public virtual short Strength => 0;

    public virtual short Speed => 0;

    public virtual short Dexterity => 0;

    public virtual short Stamina => 0;

    public virtual short Health => 0;

    public virtual short Beauty => 0;

    public virtual short Intelligence => 0;

    public virtual short WillPower => 0;

    public virtual short Astral => 0;
}
