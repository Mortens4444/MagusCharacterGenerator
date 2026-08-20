using MAGUS.Enums;
using MAGUS.GameSystem.Magic;
using MAGUS.Utils;

namespace MAGUS.Qualifications.Magic;

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

    public override MagicSchool School => MagicSchool.Shaman;
}
