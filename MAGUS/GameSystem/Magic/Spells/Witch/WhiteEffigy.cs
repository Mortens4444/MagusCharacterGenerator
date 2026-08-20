using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Fehérbábu (Boszorkány — Viaszbábok mágiája, Első Törvénykönyv p.228). A reusable wax doll
/// (not a one-shot spell) that transmits a stabbing pain of up to 1D6 Fp per round to a bonded
/// victim wherever they are; can only reduce Fp, never Ép, and the sympathetic bond breaks if
/// the victim loses consciousness. CastingTimeInSegments/DurationInRounds are nominal
/// placeholders since the book gives this no such fields (it's a crafted item usable
/// indefinitely by anyone, not just the witch who made it).
/// </summary>
public sealed class WhiteEffigy : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "White effigy";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 33;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
