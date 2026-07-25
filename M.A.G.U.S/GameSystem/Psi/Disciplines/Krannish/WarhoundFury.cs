using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Psi.Disciplines.Krannish;

public sealed class WarhoundFury : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Warhound fury";

    public PsiKind PsiKind => PsiKind.Krannish;

    public int InitiateValue => 32;

    public int PsiPointCost => 3;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
