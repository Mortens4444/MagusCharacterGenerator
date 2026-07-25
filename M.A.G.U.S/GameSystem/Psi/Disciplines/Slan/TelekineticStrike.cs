using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Psi.Disciplines.Slan;

public sealed class TelekineticStrike : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Telekinetic strike";

    public PsiKind PsiKind => PsiKind.Slan;

    public int InitiateValue => 35;

    public int PsiPointCost => 4;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D8)]
    public int GetDamage() => diceThrow._1D8();
}
