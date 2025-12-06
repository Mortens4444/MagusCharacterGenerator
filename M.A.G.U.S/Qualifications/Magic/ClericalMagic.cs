using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class ClericalMagic : Sorcery
{
    private readonly DiceThrow diceThrow = new DiceThrow();

    public ClericalMagic()
    {
        ManaPoints = 9;
    }

    public override int GetManaPointsModifier()
    {
        return diceThrow._1D3() + 6;
    }

    public override string Name => "Clerical magic";
}
