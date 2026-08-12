using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

public sealed class MindBlast : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Mind blast";

    public PsiKind PsiKind => PsiKind.Kyr;

    public int InitiateValue => 40;

    public int PsiPointCost => 5;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
