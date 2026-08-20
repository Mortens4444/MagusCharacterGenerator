using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzfal (Tűzvarázsló, Első Törvénykönyv p.273). One of the fire school's six basic forms: a
/// half-foot-thick, 5-lépés-radius semicircular vertical wall of flame that ignites flammables
/// and damages anyone crossing through it. Fire-school damage bypasses magic resistance entirely
/// per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireWall : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire wall";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
