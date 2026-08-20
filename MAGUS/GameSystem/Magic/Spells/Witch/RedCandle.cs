using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Vörös gyertya (Boszorkány — Gyertyamágia, Első Törvénykönyv p.226). Dual
/// Asztrális+Mentális resistance in the book, Astral modeled here. Casting time is nominal (the
/// candle burns for 5 minutes = 30 rounds instead of a normal cast+duration split). Puts anyone
/// who breathes the smoke to sleep by the end of round 1 unless they resist; represented as a
/// heavy combat-value penalty.
/// </summary>
public sealed class RedCandle : ISpell
{
    private const int Penalty = 50;

    public string Name => "Red candle";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 6;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 30;

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
