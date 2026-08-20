using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Gyilokvágy (Boszorkánymester — Asztrálmágia, Első Törvénykönyv p.256). Duration is kör/szint in
/// the book; level-1 baseline shown, not level-scaled. Drives the victim into a reckless killing
/// frenzy — attacks everyone nearby including allies, fights past unconsciousness; represented as
/// a mixed combat-value modifier (reckless offense, exposed defense) rather than a true
/// berserk/uncontrolled-AI state.
/// </summary>
public sealed class BerserkRage : ISpell
{
    public string Name => "Berserk rage";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => 6;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = 30,
            DefenseValue = -40,
            InitiateValue = 10,
            AimValue = 0
        });
    }
}
