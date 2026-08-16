using MAGUS.Enums;
using MAGUS.GameSystem;

namespace MAGUS.Interfaces;

public interface IPsiDiscipline
{
    string Name { get; }

    /// <summary>Power rolled against the target's magic resistance. Null means the discipline bypasses the resistance roll entirely (always connects); 0 is a valid, rollable power.</summary>
    int? Power { get; }

    int PsiPointCost { get; }

    MagicResistanceType ResistanceType { get; }

    /// <summary>How many of a round's 10 segments it takes to invoke this discipline. Most take 1, letting up to 10 fire in a single round.</summary>
    int CastingTimeInSegments { get; }

    /// <summary>How many rounds the effect lasts. 1 = instantaneous (this round only); more means it keeps ticking on the target each round after.</summary>
    int DurationInRounds { get; }

    int GetDamage();

    /// <summary>Extra, non-damage effect applied once the discipline successfully connects (e.g. reducing the target's stats or psi shields). No-op by default; most damage-dealing disciplines don't need one.</summary>
    void OnHit(Attacker caster, Attacker target) { }
}
