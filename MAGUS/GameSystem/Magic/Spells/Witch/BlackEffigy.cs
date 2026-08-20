using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Feketebábu (Boszorkány — Viaszbábok mágiája, Első Törvénykönyv p.228). The most dangerous
/// effigy — a well-placed pin (through the eye, the heart) can be instantly lethal; represented
/// directly as a kill-on-hit rather than a damage roll, matching the LavaFlow/BlackDeathDisease-
/// style convention used elsewhere. Doesn't work on an unconscious victim (not enforced here).
/// CastingTimeInSegments/DurationInRounds are nominal placeholders, see WhiteEffigy's note.
/// </summary>
public sealed class BlackEffigy : ISpell
{
    public string Name => "Black effigy";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 66;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints = 0;
    }
}
