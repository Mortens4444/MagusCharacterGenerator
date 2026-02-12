using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Magic;

namespace M.A.G.U.S.Qualifications.Magic;

public class ClericalMagic : Sorcery
{
    private readonly DiceThrow diceThrow = new();

    public ClericalMagic()
    {
        ManaPoints = 9;
    }

    [DiceThrow(ThrowType._1D3)]
    [DiceThrowModifier(6)]
    public override int GetManaPointsModifier()
    {
        return diceThrow._1D3() + 6;
    }

    public override string Name => "Clerical magic";
}
