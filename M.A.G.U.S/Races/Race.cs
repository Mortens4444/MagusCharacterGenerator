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

    public virtual sbyte Strength => 0;

    public virtual sbyte Speed => 0;

    public virtual sbyte Dexterity => 0;

    public virtual sbyte Stamina => 0;

    public virtual sbyte Health => 0;

    public virtual sbyte Beauty => 0;

    public virtual sbyte Intelligence => 0;

    public virtual sbyte Willpower => 0;

    public virtual sbyte Astral => 0;

    public sbyte Bravery => 0;

    public sbyte Erudition => 0;

    public sbyte Detection => 0;
}
