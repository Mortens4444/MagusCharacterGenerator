using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Interfaces;

public interface ISpell
{
    string Name { get; }

    MagicSchool School { get; }

    int InitiateValue { get; }

    int ManaCost { get; }

    MagicResistanceType ResistanceType { get; }

    /// <summary>How many of a round's 10 segments it takes to cast this spell. Most take 1, letting up to 10 fire in a single round.</summary>
    int CastingTimeInSegments { get; }

    /// <summary>How many rounds the effect lasts. 1 = instantaneous (this round only); more means it keeps ticking on the target each round after.</summary>
    int DurationInRounds { get; }

    int GetDamage();
}
