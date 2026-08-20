using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Futótűz (Boszorkány — Tűzmágia, Első Törvénykönyv p.207). A mindless fire creature that chases
/// a designated target, burning anything in its path. Represents the creature's ongoing touch
/// damage as it chases its target; the book's separate 5D6 catch-and-explode burst when it
/// finally reaches the victim isn't modeled here.
/// </summary>
public sealed class WildfireHound : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Wildfire hound";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 26;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 15;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
