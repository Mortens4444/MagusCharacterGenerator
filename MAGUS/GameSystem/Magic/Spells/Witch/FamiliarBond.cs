using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Összetartozás (Boszorkány — Familiáris Mágia, Első Törvénykönyv p.231-232). Dual
/// Asztrális+Mentális resistance in the book, Astral modeled here. Bonds the witch to an animal
/// familiar (shared senses, remote control, shared Fp loss) until the familiar dies;
/// approximated as a long but finite duration. Only works on non-intelligent animals.
/// </summary>
public sealed class FamiliarBond : ISpell
{
    public string Name => "Familiar bond";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
