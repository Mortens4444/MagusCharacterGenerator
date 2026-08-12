using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Jann;

public sealed class WillCrush : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Will crush";

    public PsiKind PsiKind => PsiKind.Jann;

    public int InitiateValue => 42;

    public int PsiPointCost => 6;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
