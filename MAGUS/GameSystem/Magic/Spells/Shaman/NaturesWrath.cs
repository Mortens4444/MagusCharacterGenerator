using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Gyilkos természet (Sámán — Természeti mágia, Második Törvénykönyv p.128-129). Similar to
/// Növénycsapda but savage: local plants and animals within range turn feral and hurl themselves at
/// marked targets to kill, dealing a minimum of 7D6 SP (rising 1D6 every 3 shaman levels, not
/// modeled) and needing no further direction once unleashed.
/// </summary>
public sealed class NaturesWrath : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Nature's wrath";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 31;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 2;

    [DiceThrow(ThrowType._7D6)]
    public int GetDamage() => diceThrow._7D6();
}
