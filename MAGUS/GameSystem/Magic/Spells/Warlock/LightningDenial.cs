using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villám tagadás (Boszorkánymester — Villámmágia, Első Törvénykönyv p.244). Protects the
/// caster or one ally within range from natural lightning/raw-energy damage, harmlessly
/// grounding it. Duration is kör/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class LightningDenial : ISpell
{
    public string Name => "Lightning denial";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
