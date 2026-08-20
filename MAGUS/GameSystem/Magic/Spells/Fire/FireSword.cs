using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzkard (Tűzvarázsló, Első Törvénykönyv p.273). One of the fire school's six basic forms:
/// wreathes a one-handed blade in flame, adding fire damage and igniting flammables it touches
/// on top of the weapon's own damage. Fire-school damage bypasses magic resistance entirely per
/// the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireSword : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire sword";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 5;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
