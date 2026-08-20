using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Visszaverődő villám (Boszorkánymester — Villámmágia, Első Törvénykönyv p.242-243). Book lets
/// this bolt bounce off non-conductive surfaces (stone, wood, glass) to hit targets in cover;
/// the bounce mechanic isn't modeled here, this represents the bolt's damage.
/// </summary>
public sealed class ReflectingLightning : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Reflecting lightning";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
