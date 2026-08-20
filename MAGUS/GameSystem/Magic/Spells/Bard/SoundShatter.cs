using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangcsapás (Bárd — Hangmágia, Első Törvénykönyv p.139). A shrieking noise that shatters
/// non-magical glass and mirrors nearby. Deals no HP damage.
/// </summary>
public sealed class SoundShatter : ISpell
{
    public string Name => "Sound shatter";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
