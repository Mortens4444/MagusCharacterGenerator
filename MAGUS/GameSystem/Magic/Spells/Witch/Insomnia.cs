using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Álmatlanság (Boszorkány — Lélekvarázs, Első Törvénykönyv p.219). Dual Asztrális+Mentális
/// resistance in the book, Astral modeled here. Prevents the victim from sleeping for 1 day (8640
/// rounds); the book's escalating penalties and eventual coma on the 8th sleepless night aren't
/// modeled.
/// </summary>
public sealed class Insomnia : ISpell
{
    public string Name => "Insomnia";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
