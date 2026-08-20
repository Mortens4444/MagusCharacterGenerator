using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Távoli tűz (Tűzvarázsló, Első Törvénykönyv p.277). One of the oldest uses of mundane fire:
/// lets the caster send blurry images to anyone they personally know, provided both parties stay
/// near a fire of at least Strength 1 for the whole duration. One-directional unless the
/// recipient also knows fire magic. Deals no damage and isn't wired into the enemy-targeting
/// combat pipeline. No magic-resistance roll applies since no mental link is formed, hence
/// Power is null.
/// </summary>
public sealed class DistantFire : ISpell
{
    public string Name => "Distant fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
