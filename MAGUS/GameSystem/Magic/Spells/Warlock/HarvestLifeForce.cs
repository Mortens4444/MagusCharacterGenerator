using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Életerő-begyűjtés (Boszorkánymester — Nekromancia, Első Törvénykönyv p.258-259). Book converts
/// the drained life force into Mana points for the caster instead of healing; not modeled here
/// since Attacker has no generic mana-points setter (only Character does, via a different code
/// path).
/// </summary>
public sealed class HarvestLifeForce : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Harvest life force";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 16;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D10)]
    public int GetDamage() => diceThrow._2D10();
}
