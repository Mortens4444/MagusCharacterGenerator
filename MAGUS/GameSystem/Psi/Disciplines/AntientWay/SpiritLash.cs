using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.AntientWay;

public sealed class SpiritLash : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Spirit lash";

    public PsiKind PsiKind => PsiKind.AntientWay;

    public int InitiateValue => 30;

    public int PsiPointCost => 4;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
