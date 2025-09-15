using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class WarlockMagic : Sorcery
{
    public WarlockMagic()
    {
        ManaPoints = 7;
    }

    public override string Name => "Warlock magic";
}
