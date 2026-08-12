using MAGUS.Enums;
using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

public class OrdanianFlameGuardFireMagic : Sorcery
{
    public OrdanianFlameGuardFireMagic()
    {
        ManaPoints = 10;
    }

    public override string Name => "Fire magic";

    public override MagicSchool School => MagicSchool.Fire;

    public override int GetManaPointsModifier()
    {
        return 0;
    }
}
