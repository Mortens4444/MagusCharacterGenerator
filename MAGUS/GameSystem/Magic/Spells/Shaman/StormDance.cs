using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Vihartánc (Sámán — Természeti mágia, Második Törvénykönyv p.126). Summons dark storm clouds
/// over a chosen area (up to 2 kilometers per Tapasztalati Szint away); once the storm breaks,
/// anyone under open sky for more than a minute risks being struck by random lightning bolts for
/// 6D6 SP each, repeating every round until the hour-long storm passes or the shaman cancels it.
/// </summary>
public sealed class StormDance : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Storm dance";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 40;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 610;

    public int DurationInRounds => 360;

    [DiceThrow(ThrowType._6D6)]
    public int GetDamage() => diceThrow._6D6();
}
