using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Átokvarázs (Boszorkánymester — Átkok, Első Törvénykönyv p.246-247). Curses a victim with
/// physical weakness, draining an ability score or combat values. Represented here as a flat
/// combat-value penalty on hit. Book Mana cost varies by curse type per a table that was
/// illegible in the scanned source page; 20 is a representative estimate. Book duration is 1
/// month, extendable; approximated as a long but finite value. Resisted by an Egészségpróba
/// (Health check), not magic resistance, per the book — closest available ResistanceType used.
/// </summary>
public sealed class CurseSpell : ISpell
{
    public string Name => "Curse spell";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -20,
            DefenseValue = -20,
            InitiateValue = -20,
            AimValue = -20
        });
    }
}
