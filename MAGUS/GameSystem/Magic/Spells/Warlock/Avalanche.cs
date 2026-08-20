using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Lavina (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.255). Only usable on steep,
/// snow-covered mountain slopes. Triggers a landslide of snow down a 1-mile stretch, burying and
/// crushing anyone caught in its path.
/// </summary>
public sealed class Avalanche : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Avalanche";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 50;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    [DiceThrow(ThrowType._7D6)]
    public int GetDamage() => diceThrow._7D6();
}
