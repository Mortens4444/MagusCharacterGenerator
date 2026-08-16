using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Other;

/// <summary>Generic fallback spell for sorcery types that don't (yet) have their own dedicated spell list (bardic, lore, saman magic).</summary>
public sealed class ArcaneBolt : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Arcane bolt";

    public MagicSchool School => MagicSchool.Other;

    public int? Power => 6;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
