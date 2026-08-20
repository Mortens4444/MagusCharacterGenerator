using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Zavarás (Kyr metódus, p.126). A short mental strike that breaks a target's concentration,
/// meditation, or trance — instantly ending almost any Psi discipline they're sustaining (Tetszhalál
/// is the one exception). Succeeds automatically once the caster commits at least 1 more Psi point
/// than the sum of the target's mental Statikus+Dinamikus Pajzs strength (no further resistance
/// roll applies at that point) — doesn't break the shields themselves, just slips through them.
/// On a successful hit, the target can't use Psi or cast spells that round or the next. Represented
/// as a short combat-value penalty rather than a true concentration-breaking flag, since Attacker
/// has no such state. Doc note: the shield-strength-comparison mechanic isn't modeled — Power is
/// null (bypasses the normal resistance roll, per the book's "nincs helye további TME-nek" once
/// enough Psi points are committed).
/// </summary>
public sealed class Disruption : IPsiDiscipline
{
    private const int Penalty = 25;

    public string Name => "Disruption";

    public int? Power => null;

    public int PsiPointCost => 20;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

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
