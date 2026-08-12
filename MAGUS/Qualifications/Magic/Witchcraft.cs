using MAGUS.Enums;
using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

public class Witchcraft : Sorcery
{
    public Witchcraft()
    {
        ManaPoints = 8;
    }

    public override MagicSchool School => MagicSchool.Witch;
}
