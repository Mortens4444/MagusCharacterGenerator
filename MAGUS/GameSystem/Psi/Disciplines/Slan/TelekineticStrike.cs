using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

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
