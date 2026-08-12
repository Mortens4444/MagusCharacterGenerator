using MAGUS.Enums;
using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

public class FireMagic : Sorcery
{
    public FireMagic()
    {
        ManaPoints = 6;
    }

    public override string Name => "Fire magic";

    public override MagicSchool School => MagicSchool.Fire;
}
