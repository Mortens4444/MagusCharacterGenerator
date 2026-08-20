using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kriptacsók (Boszorkány — Csókmágia, Első Törvénykönyv p.224, Type: Necromancia). Ages the
/// victim up to 80 years old (1 year per round of contact); represented as a flat combat-value
/// penalty for reduced physical capability rather than a true aging/stat-reduction mechanic. The
/// book grants the target no resistance roll at all against this spell, so Power is null here to
/// represent it always connecting. Book duration is "1 nap (vagy lásd Csókmágia)" — the base
/// 1-day figure is shown; the extension clause isn't modeled.
/// </summary>
public sealed class CryptKiss : ISpell
{
    private const int Penalty = -20;

    public string Name => "Crypt kiss";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 49;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = Penalty,
            DefenseValue = Penalty,
            InitiateValue = Penalty,
            AimValue = Penalty
        });
    }
}
