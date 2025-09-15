using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.GameSystem.Magic;

public abstract class Sorcery : SpecialQualification
{
    public ushort ManaPoints { get; set; }

    public virtual ushort GetManaPointsModifier()
    {
        return ManaPoints;
    }
}
