using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Növénycsapda (Sámán — Természeti mágia, Második Törvénykönyv p.130-131). Cast in thick woods,
/// scrub or reeds: vines, brambles and roots lash out (about 80% success, varying with local
/// vegetation density) to bind and pull down up to (level/2) marked victims, who then fight prone,
/// bound and at a location disadvantage. Modeled as a heavy combat-value penalty rather than a true
/// grappled/prone status.
/// </summary>
public sealed class PlantSnare : ISpell
{
    public string Name => "Plant snare";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 16;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 7;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -30,
            DefenseValue = -30
        });
    }
}
