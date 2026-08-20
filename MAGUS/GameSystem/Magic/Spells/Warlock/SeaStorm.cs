using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Tenger felkorbácsolása (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.255). Only
/// usable on large bodies of water. Whips up a violent storm with towering waves; the damage
/// here represents harm to ships and structures caught in the storm.
/// </summary>
public sealed class SeaStorm : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Sea storm";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 40;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    [DiceThrow(ThrowType._10D6)]
    public int GetDamage() => diceThrow._10D6();
}
