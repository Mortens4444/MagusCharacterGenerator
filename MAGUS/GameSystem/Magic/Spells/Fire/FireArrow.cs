using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Shared by Fire Mages (native Fire school) and Wizards, who get it under their own Mosaic
/// school via a second SpellCatalog entry constructed with school: MagicSchool.Mosaic.
/// </summary>
public sealed class FireArrow(MagicSchool school = MagicSchool.Fire) : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire arrow";

    public MagicSchool School => school;

    public int? Power => 7;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D8)]
    public int GetDamage() => diceThrow._1D8();
}
