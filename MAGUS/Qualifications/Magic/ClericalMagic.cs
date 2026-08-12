using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Magic;

namespace MAGUS.Qualifications.Magic;

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

    public override MagicSchool School => MagicSchool.Priest;
}
