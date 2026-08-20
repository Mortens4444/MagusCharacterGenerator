using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Irtózat (Boszorkány — Asztrálmágia, Első Törvénykönyv p.213). Instills a dread revulsion toward
/// a chosen object/type of object; proximity to it disorients the victim. Matches the book's flat
/// -15 to all rolls. No explicit duration given; a representative 60-round value is used here.
/// </summary>
public sealed class Loathing : ISpell
{
    private const int Penalty = 15;

    public string Name => "Loathing";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 60;

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
