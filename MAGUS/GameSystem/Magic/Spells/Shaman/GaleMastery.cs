using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szélirányítás (Sámán — Természeti mágia, Második Törvénykönyv p.126-127). Puts the wind
/// entirely under the shaman's control (0-200 km/h, any direction, requires no concentration to
/// maintain), able to whip up a devastating sandstorm (visibility down to 1 meter, -25 TÉ/-35 VÉ
/// for anyone inside) or a mountainside avalanche dealing 8D6 SP to everyone in its path; winds
/// above 140 km/h can also fling creatures for 4D6-11D6 SP. Only the avalanche's flat 8D6 damage
/// figure is modeled; the sandstorm's combat penalties and the wind-fling damage range are not.
/// </summary>
public sealed class GaleMastery : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Gale mastery";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 38;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 210;

    public int DurationInRounds => 360;

    [DiceThrow(ThrowType._8D6)]
    public int GetDamage() => diceThrow._8D6();
}
