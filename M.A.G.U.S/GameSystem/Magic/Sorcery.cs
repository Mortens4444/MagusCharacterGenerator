using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.GameSystem.Magic;

public abstract class Sorcery : SpecialQualification
{
    public int ManaPoints { get; set; }

    public virtual MagicSchool School => MagicSchool.Other;

    public virtual int GetManaPointsModifier()
    {
        return ManaPoints;
    }
}
