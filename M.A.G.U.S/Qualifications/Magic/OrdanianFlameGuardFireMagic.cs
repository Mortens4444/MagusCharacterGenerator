using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class OrdanianFlameGuardFireMagic : Sorcery
{
    public OrdanianFlameGuardFireMagic()
    {
        ManaPoints = 10;
    }

    public override string Name => "Fire magic";

    public override int GetManaPointsModifier()
    {
        return 0;
    }
}
