using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Nyavalya (Sámán, Második Törvénykönyv p.113-114, Ráolvasások — Tömegre ható átkok). A spirit
/// possesses the victim and saps their body, manifesting as a hidden, level-5, immediately-acting
/// disease that halves Erő and cuts Gyorsaság/Ügyesség to three quarters, alongside a flat
/// KÉ-20/TÉ-30/VÉ-30/CÉ-10 combat penalty (mapped here to InitiateValue/AttackValue/DefenseValue/
/// AimValue) — represented directly since it matches CombatModifier's four fields. Only removable
/// early by a shaman's Átokűzés or priest exorcism. Book Erősség is 19 + caster level, book
/// duration 1 week per level; level-1 baselines used (not level-scaled). Book lists no resistance
/// (spell always takes hold); the ongoing Egészségpróba-driven disease escalation and ability-score
/// drain are not modeled.
/// </summary>
public sealed class WastingCurse : ISpell
{
    public string Name => "Wasting curse";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 60480;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            InitiateValue = -20,
            AttackValue = -30,
            DefenseValue = -30,
            AimValue = -10
        });
    }
}
