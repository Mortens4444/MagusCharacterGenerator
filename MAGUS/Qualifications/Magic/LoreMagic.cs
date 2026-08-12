using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

public class LoreMagic : Sorcery
{
    public LoreMagic()
    {
        ManaPoints = 10;
    }

    public override int GetManaPointsModifier()
    {
        return 0;
    }

    public override string Name => "Lore of magic";
}
