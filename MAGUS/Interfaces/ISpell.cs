using MAGUS.Enums;
using MAGUS.GameSystem;

namespace MAGUS.Interfaces;

public interface ISpell
{
    string Name { get; }

    MagicSchool School { get; }

    /// <summary>Which priest spheres grant this spell (a priest needs at least one, per their Deity's AvailableSpheres). Empty for non-priest spells, which are gated by School alone.</summary>
    Sphere[] Spheres => [];

    /// <summary>Power rolled against the target's magic resistance. Null means the spell bypasses the resistance roll entirely (always connects); 0 is a valid, rollable power that can still be raised via mana empowerment.</summary>
    int? Power { get; }

    int ManaCost { get; }

    /// <summary>How much extra Power each additional mana point spent when casting this specific spell buys. Varies per spell.</summary>
    int PowerBonusPerManaPoint { get; }

    MagicResistanceType ResistanceType { get; }

    /// <summary>How many of a round's 10 segments it takes to cast this spell. Most take 1, letting up to 10 fire in a single round.</summary>
    int CastingTimeInSegments { get; }

    /// <summary>How many rounds the effect lasts. 1 = instantaneous (this round only); more means it keeps ticking on the target each round after.</summary>
    int DurationInRounds { get; }

    int GetDamage();

    /// <summary>Extra, non-damage effect applied once the spell successfully connects (e.g. reducing the target's stats). No-op by default.</summary>
    void OnHit(Attacker caster, Attacker target) { }
}
