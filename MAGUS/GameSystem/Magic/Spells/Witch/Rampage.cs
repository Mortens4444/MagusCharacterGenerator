using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Ámokfutás (Boszorkány — Lélekvarázs, Első Törvénykönyv p.218-219). Dual Asztrális+Mentális
/// resistance in the book, Astral modeled here. Forces the victim into an exhausting flight from
/// an imagined horror until they collapse and die (Stamina-based, re-rollable resistance every 2
/// hours); too stateful/ongoing to model, this is a flavor-only catalog entry (DurationInRounds
/// is nominal).
/// </summary>
public sealed class Rampage : ISpell
{
    public string Name => "Rampage";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 50;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
