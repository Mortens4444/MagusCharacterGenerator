using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class Wizardry : Sorcery
{
    public Wizardry()
    {
        ManaPoints = 10;
    }

    public override MagicSchool School => MagicSchool.Mosaic;
}
