using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Psi.Disciplines.AntientWay;

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
