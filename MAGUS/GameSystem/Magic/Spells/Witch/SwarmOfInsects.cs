using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Rovarfelhő (Boszorkány — Asztrálmágia, Első Törvénykönyv p.209-210). Summons a swarm of local
/// insects/vermin to attack whoever the witch points at. The book gives no magic-resistance line
/// for this spell (Power is null), but does give a flat -25 TÉ/-25 VÉ penalty plus 1D6-2D6 damage
/// for anyone caught in the cloud; the damage itself is simplified away, only the combat penalty
/// is modeled here.
/// </summary>
public sealed class SwarmOfInsects : ISpell
{
    public string Name => "Swarm of insects";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = 0,
            DefenseValue = -25,
            InitiateValue = 0,
            AimValue = -25
        });
    }
}
