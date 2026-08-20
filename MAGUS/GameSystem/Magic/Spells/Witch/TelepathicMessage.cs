using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Üzenet (Boszorkány — Térmágia, Első Törvénykönyv p.229). Sends a telepathic message to a
/// creature the witch has marked, from unlimited distance, bypassing language barriers. Duration
/// is perc/szint; level-1 baseline shown, not level-scaled. Same branding-mark prerequisite as
/// Observation, not enforced here.
/// </summary>
public sealed class TelepathicMessage : ISpell
{
    public string Name => "Telepathic message";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
