using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűznyíl (Tűzvarázsló, Első Törvénykönyv p.272). Shared by Fire Mages (native Fire school) and
/// Wizards, who get it under their own Mosaic school via a second SpellCatalog entry constructed
/// with school: MagicSchool.Mosaic. Fire-school damage bypasses magic resistance entirely per the
/// rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireArrow(MagicSchool school = MagicSchool.Fire) : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire arrow";

    public MagicSchool School => school;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
