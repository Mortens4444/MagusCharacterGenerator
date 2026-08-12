using MAGUS.Enums;
using MAGUS.GameSystem.Psi;

namespace MAGUS.Interfaces;

public interface IPsiDiscipline
{
    string Name { get; }

    PsiKind PsiKind { get; }

    int InitiateValue { get; }

    int PsiPointCost { get; }

    MagicResistanceType ResistanceType { get; }

    /// <summary>How many of a round's 10 segments it takes to invoke this discipline. Most take 1, letting up to 10 fire in a single round.</summary>
    int CastingTimeInSegments { get; }

    /// <summary>How many rounds the effect lasts. 1 = instantaneous (this round only); more means it keeps ticking on the target each round after.</summary>
    int DurationInRounds { get; }

    int GetDamage();
}
