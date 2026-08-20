using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Forduló villám (Boszorkánymester — Villámmágia, Első Törvénykönyv p.243). Book lets this bolt
/// turn corners to hit targets fleeing down winding corridors or hiding behind walls; the
/// turning mechanic isn't modeled here, this represents the bolt's damage.
/// </summary>
public sealed class TurningLightning : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Turning lightning";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 13;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
