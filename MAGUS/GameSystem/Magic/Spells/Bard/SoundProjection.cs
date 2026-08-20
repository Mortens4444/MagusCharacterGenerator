using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangkivetítés (Bárd — Hangmágia, Első Törvénykönyv p.139). Projects the bard's own and their
/// surroundings' sounds to a different location, often paired with the Fantom illusion for a
/// convincing combined image-and-sound projection.
/// </summary>
public sealed class SoundProjection : ISpell
{
    public string Name => "Sound projection";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
