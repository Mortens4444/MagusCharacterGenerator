using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szemmelverés (Boszorkány — Asztrálmágia, Első Törvénykönyv p.210-211). The witch curses a
/// target with a mere glance. Book requires both Asztrális and Mentális resistance rolls; only
/// Astral is modeled here (ISpell has one ResistanceType). Inflicts ongoing splitting-headache
/// pain and reduced max Ép/Fp for the duration; simplified to a flat combat-value penalty rather
/// than a max-HP reduction mechanic.
/// </summary>
public sealed class EvilEye : ISpell
{
    private const int Penalty = 20;

    public string Name => "Evil eye";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -Penalty,
            DefenseValue = -Penalty,
            InitiateValue = -Penalty,
            AimValue = -Penalty
        });
    }
}
