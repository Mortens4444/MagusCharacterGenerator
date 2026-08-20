using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fantomsereg (Bárd — Fénymágia, Első Törvénykönyv p.146). Conjures the illusory image of an
/// entire troop or army of a single creature type, convincing from a distance but not up close.
/// </summary>
public sealed class PhantomArmy : ISpell
{
    public string Name => "Phantom army";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 15;

    public int GetDamage() => 0;
}
