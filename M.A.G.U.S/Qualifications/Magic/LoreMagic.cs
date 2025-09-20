using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class LoreMagic : Sorcery
{
    public LoreMagic()
    {
        ManaPoints = 10;
    }

    public override ushort GetManaPointsModifier()
    {
        return 0;
    }

    public override string Name => "Lore of magic";
}
