using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kín szava (Boszorkány — Mentálmágia, Tömegbefolyásoló varázslatok, Első Törvénykönyv p.220).
/// Mass version of Kín okozás: one spoken word inflicts agony on everyone who hears it. Book
/// inflicts 75% of current Fp loss and 3 rounds of total incapacitation (Akaraterő-próba to
/// resist total helplessness); simplified here to a flat -30 combat-value penalty rather than an
/// Fp-percentage loss. Power/Erősség is 20+caster level in the book; level-1 baseline (21) shown,
/// not level-scaled. Not further empowerable — the book states this power cannot be increased with
/// extra Mana beyond its base cost.
/// </summary>
public sealed class WordOfAgony : ISpell
{
    private const int Penalty = 30;

    public string Name => "Word of agony";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 21;

    public int ManaCost => 50;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3;

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
