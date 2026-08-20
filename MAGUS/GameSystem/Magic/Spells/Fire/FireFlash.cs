using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzobbanás (Tűzvarázsló, Első Törvénykönyv p.276-277). An existing fire flares into a
/// blinding flash; anyone nearby who saw it risks permanent or temporary blindness. Represents
/// the blinding effect as a large combat-value penalty rather than modeling separate
/// temporary/permanent blindness chances. Fire-school damage bypasses magic resistance entirely
/// per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireFlash : ISpell
{
    private const int Penalty = 40;

    public string Name => "Fire flash";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

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
