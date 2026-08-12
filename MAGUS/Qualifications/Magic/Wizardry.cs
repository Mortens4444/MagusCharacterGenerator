using MAGUS.Enums;
using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

public class Wizardry : Sorcery
{
    public Wizardry()
    {
        ManaPoints = 10;
    }

    public override MagicSchool School => MagicSchool.Mosaic;
}
