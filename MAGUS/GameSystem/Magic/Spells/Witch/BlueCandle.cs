using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kék gyertya (Boszorkány — Gyertyamágia, Első Törvénykönyv p.226). Single Mentális resistance
/// (not dual). Contains the same Bódulat (daze) effect as the witch's Mentálmágia stun spell,
/// stabilized for as long as the candle keeps burning; represented as a combat-value penalty.
/// </summary>
public sealed class BlueCandle : ISpell
{
    public string Name => "Blue candle";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 6;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            InitiateValue = -15,
            AttackValue = -20,
            DefenseValue = -20,
            AimValue = -20
        });
    }
}
