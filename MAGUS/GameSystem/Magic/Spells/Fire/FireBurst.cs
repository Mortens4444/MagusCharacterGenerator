using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzkitörés (Tűzvarázsló, Első Törvénykönyv p.273). One of the fire school's six basic forms:
/// an instantaneous explosion centered on a chosen point within the caster's zone, damaging
/// everyone within its radius. Fire-school damage bypasses magic resistance entirely per the
/// rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireBurst : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire burst";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
