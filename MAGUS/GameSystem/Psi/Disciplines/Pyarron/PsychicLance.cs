using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Pyarron;

public sealed class PsychicLance : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Psychic lance";

    public PsiKind PsiKind => PsiKind.Pyarron;

    public int InitiateValue => 35;

    public int PsiPointCost => 4;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D8)]
    public int GetDamage() => diceThrow._1D8();
}
