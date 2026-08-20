using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Belső tűz (Tűzvarázsló, Első Törvénykönyv p.281). Az áldozat ereiben égető fájdalmat kelt,
/// ha elveszíti Egészségpróbáját. The book's damage escalates every 2 rounds (1D6, then 2D6,
/// then 3D6...) resisted by an Egészségpróba (Health check), not magic resistance; simplified
/// here to a flat 1D6 per round. Fire-school damage bypasses magic resistance entirely per the
/// rulebook (p.267), hence Power is null.
/// </summary>
public sealed class InnerFire : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Inner fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 19;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
