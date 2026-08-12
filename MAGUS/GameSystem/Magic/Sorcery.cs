using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;

namespace MAGUS.GameSystem.Magic;

public abstract class Sorcery : SpecialQualification
{
    public int ManaPoints { get; set; }

    public virtual MagicSchool School => MagicSchool.Other;

    public virtual int GetManaPointsModifier()
    {
        return ManaPoints;
    }
}
