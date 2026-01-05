using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.Qualifications.Magic;

public class SamanMagic : Sorcery
{
    private readonly int manaPointsModifier;

    public SamanMagic(int willPower)
    {
        ManaPoints = 7;
        manaPointsModifier = MathHelper.GetAboveAverageValue(willPower);
    }

    public override int GetManaPointsModifier()
    {
        return manaPointsModifier;
    }

    public override string Name => "Saman magic";
}
