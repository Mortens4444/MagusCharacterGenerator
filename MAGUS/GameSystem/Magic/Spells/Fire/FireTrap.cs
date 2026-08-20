using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzcsapda (Tűzvarázsló, Első Törvénykönyv p.279). Láthatatlan pentagrammát rejt el, amely
/// felcsapó lángokkal sebzi azt, aki a jelölt területre lép. Fire-school damage bypasses magic
/// resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireTrap : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire trap";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 13;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1080;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
