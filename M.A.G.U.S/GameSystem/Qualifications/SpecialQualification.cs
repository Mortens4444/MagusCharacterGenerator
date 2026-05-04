namespace M.A.G.U.S.GameSystem.Qualifications;

public abstract class SpecialQualification : ISpecialQualification
{
    public virtual string Name => GetType().Name;

    public string Note = String.Empty;

    public override string ToString() => String.Empty;
}
