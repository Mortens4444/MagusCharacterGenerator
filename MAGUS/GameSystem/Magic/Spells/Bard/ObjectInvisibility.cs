using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Tárgy láthatatlanság (Bárd — Fénymágia, Első Törvénykönyv p.141-142). Hides a single object's
/// image (up to 1×1×1 láb per level) — it stays tangible, audible, and smellable, just invisible.
/// Book gives -25 VÉ to melee attackers if applied to the bard's own weapon (-50 if thrown/shot,
/// not modeled here). Duration is 3 kör/szint; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class ObjectInvisibility : ISpell
{
    private const int Penalty = 25;

    public string Name => "Object invisibility";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3;

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
