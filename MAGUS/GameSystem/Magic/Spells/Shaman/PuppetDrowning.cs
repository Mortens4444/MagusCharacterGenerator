using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Fullasztás (Sámán — Zotgejt/Vérszimpatikus mágia, Második Törvénykönyv p.135). The shaman
/// dunks the victim's Zotgejt puppet in water and dances over it; the real victim's lungs fill with
/// water, and they choke under Kábultság rules despite breathing normally, drowning outright if the
/// spell outlasts their Állóképesség in rounds. Modeled as a heavy combat-value penalty representing
/// the daze/choke rather than a true drowning-death subsystem.
/// </summary>
public sealed class PuppetDrowning : ISpell
{
    public string Name => "Puppet drowning";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 51;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -30,
            DefenseValue = -30,
            InitiateValue = -30,
            AimValue = -30
        });
    }
}
