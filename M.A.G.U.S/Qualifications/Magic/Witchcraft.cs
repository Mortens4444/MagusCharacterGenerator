using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class Witchcraft : Sorcery
{
    public Witchcraft()
    {
        ManaPoints = 8;
    }

    public override MagicSchool School => MagicSchool.Witch;
}
