using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzaura (Tűzvarázsló, Első Törvénykönyv p.274). One of the fire school's six basic forms:
/// wraps the caster (or a chosen ally) in a ring of flame that doesn't harm or hinder its
/// wearer, but burns anyone who reaches through it to touch or strike them. Fire-school damage
/// bypasses magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireAura : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire aura";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 2;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
