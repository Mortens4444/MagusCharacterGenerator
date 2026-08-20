using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Folyadékpusztítás (Boszorkánymester — Anyagmágia, Első Törvénykönyv p.244). Annihilates 1
/// liter of non-magical liquid outright; cannot target bodily fluids of living creatures.
/// </summary>
public sealed class DestroyLiquid : ISpell
{
    public string Name => "Destroy liquid";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
