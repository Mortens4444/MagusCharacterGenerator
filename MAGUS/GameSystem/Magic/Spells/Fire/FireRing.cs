using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzgyűrű (Tűzvarázsló, Első Törvénykönyv p.275). A 3-foot-diameter ring of low flame surrounds
/// the caster; anything crossing it is engulfed. Fire-school damage bypasses magic resistance
/// entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireRing : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire ring";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 10;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
