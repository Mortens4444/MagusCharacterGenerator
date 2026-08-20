using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Figyelem elterelés (Bárd — Egyéb bárdmágiák, Első Törvénykönyv p.149, Type: Fény+Hangmágia).
/// Briefly draws bystanders' attention away from the bard with a small illusory sight or sound.
/// </summary>
public sealed class AttentionDiversion : ISpell
{
    public string Name => "Attention diversion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
