using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Mágikus Tekintet (Kyr metódus, p.129). Locks eyes with the target, who must make an
/// Akaraterő-próba (willpower check) or become unable to look away — they can act, flee, or even
/// attack the wizard, but never anything that would break eye contact (won't turn away, won't
/// step behind cover). Only ends if the wizard looks away first or a third party blocks the
/// sightline for even a moment. While the victim is held, the wizard's Astral/Mental magic against
/// them gains a level-dependent bonus (per a table not reproduced here). Represented as a
/// defense-value penalty (transfixed, unable to actively evade) rather than a true
/// can't-look-away state, since Attacker has no such flag. Book resistance is an Akaraterő-próba
/// (willpower check), mapped to Mental here as the closest fit.
/// </summary>
public sealed class MagicGaze : IPsiDiscipline
{
    private const int DefenseValuePenalty = 30;

    public string Name => "Magic gaze";

    public int? Power => 1;

    public int PsiPointCost => 4;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier { DefenseValue = -DefenseValuePenalty });
    }
}
