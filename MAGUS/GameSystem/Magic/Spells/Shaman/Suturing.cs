using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Forrasztás (Sámán, Második Törvénykönyv p.108, Ráolvasások). Opens the Ráolvasások (Divinations)
/// chapter: a quick, trance-free chant that closes minor surface wounds on one person. Book cost is
/// 2 Mp, or alternatively 1 Mp + 1 FP; the flat 2 Mp option is used here, the FP-substitute path
/// left unmodeled. The book gives no explicit healing formula for a "minor" wound, so the amount
/// healed is approximated with the same 1D6 baseline the codebase already uses for a comparable
/// minor heal (Witch's KissOfLife).
/// </summary>
public sealed class Suturing : IHealingSpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Suturing";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.ActualHealthPoints += diceThrow._1D6();
    }
}
