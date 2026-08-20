using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Akarat elorzása (Boszorkány — Ölelésmágia, Első Törvénykönyv p.226). Turns the victim into a
/// puppet who obeys every command and later forgets what they did. Duration is "1 óra/szint
/// (vagy amíg a boszorkány ébren van)" in the book; level-1 baseline (360 = 1 hour) shown, the
/// "or while the witch stays awake" extension isn't modeled.
/// </summary>
public sealed class WillTheft : ISpell
{
    private const int Penalty = 40;

    public string Name => "Will theft";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 24;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

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
