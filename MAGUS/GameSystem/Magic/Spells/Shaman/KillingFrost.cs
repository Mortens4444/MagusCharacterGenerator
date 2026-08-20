using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Fagy (Sámán — Természeti mágia, Második Törvénykönyv p.126). Plunges the area's temperature to
/// -20/-30 C over 4 rounds; those caught inside lose 1 SP/round bundled up or 3 SP/round exposed,
/// plus their KÉ/TÉ/VÉ/CÉ erode over time until death by exposure. Heavily simplified to a flat
/// per-round SP drain (the unclothed case) and a small flat combat-value penalty in place of the
/// book's escalating, minutes-long stat decay.
/// </summary>
public sealed class KillingFrost : ISpell
{
    public string Name => "Killing frost";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 170;

    public int DurationInRounds => 90;

    public int GetDamage() => 3;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -1,
            DefenseValue = -1,
            InitiateValue = -1,
            AimValue = -1
        });
    }
}
