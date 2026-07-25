using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Psi.Disciplines.Monk;

public sealed class InnerFistStrike : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Inner fist strike";

    public PsiKind PsiKind => PsiKind.Monk;

    public int InitiateValue => 38;

    public int PsiPointCost => 4;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
