using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Vörösbábu (Boszorkány — Viaszbábok mágiája, Első Törvénykönyv p.228). Like WhiteEffigy but
/// causes an actual wound (up to 1D3 Ép per round instead of Fp) requiring the victim's blood
/// mixed into the wax at creation; can't kill outright (vital organs are unaffected) but can
/// bleed the victim toward death. CastingTimeInSegments/DurationInRounds are nominal
/// placeholders, see WhiteEffigy's note.
/// </summary>
public sealed class RedEffigy : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Red effigy";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 55;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    [DiceThrow(ThrowType._1D3)]
    public int GetDamage() => diceThrow._1D3();
}
