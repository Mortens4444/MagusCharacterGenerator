using MAGUS.Enums;
using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

public class Warlockry : Sorcery
{
    public Warlockry()
    {
        ManaPoints = 7;
    }

    public override MagicSchool School => MagicSchool.Warlock;
}
