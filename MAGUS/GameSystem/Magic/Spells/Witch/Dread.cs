using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Rettegés (Boszorkány — Asztrálmágia, Első Törvénykönyv p.213). Fills victims with dread at the
/// sight of the witch; they flee if possible, or fight in a cornered panic. Matches the book's
/// KÉ-15 TÉ-10 VÉ+5 CÉ-20 exactly. No explicit duration given; a representative 60-round value is
/// used here.
/// </summary>
public sealed class Dread : ISpell
{
    public string Name => "Dread";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -10,
            DefenseValue = 5,
            InitiateValue = -15,
            AimValue = -20
        });
    }
}
