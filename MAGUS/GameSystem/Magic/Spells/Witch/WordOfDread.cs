using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Rettegés szava (Boszorkány — Asztrálmágia, Tömegbefolyásoló varázslatok, Első Törvénykönyv
/// p.220). Mass version of Rettegés (Dread): the witch speaks one word and everyone who sees her
/// falls under the same effect. Power/Erősség is 20+caster level in the book; level-1 baseline
/// (21) shown, not level-scaled. Duration is "1 óra/szint"; level-1 baseline shown. Not further
/// empowerable — the book states "A varázslat nem erősíthető."
/// </summary>
public sealed class WordOfDread : ISpell
{
    public string Name => "Word of dread";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 21;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 360;

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
