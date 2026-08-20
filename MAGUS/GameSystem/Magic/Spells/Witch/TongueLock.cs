using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Nyelvbéklyó (Boszorkány — Mentálmágia, Első Törvénykönyv p.218). Locks a single word, phrase,
/// or name so the target can't speak, think of, or write it. Book duration is 1 week if
/// unwilling (or until the caster releases it if the victim consents); approximated as a long
/// but finite value. Originally a Shadonian secret — usable by both Witches and Warlocks per the
/// book, implemented here on the Witch school only since that's the class currently being added.
/// </summary>
public sealed class TongueLock : ISpell
{
    public string Name => "Tongue lock";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 20;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
