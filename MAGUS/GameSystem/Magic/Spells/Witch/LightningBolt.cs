using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>Cast independently by both Witch and Warlock, registered separately per school in SpellCatalog.</summary>
public sealed class LightningBolt(MagicSchool school = MagicSchool.Witch) : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning bolt";

    public MagicSchool School => school;

    public int? Power => 9;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 3;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
