using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Delej (Sámán — Szabad mágia, Második Törvénykönyv p.120-121). An exhausting Szellemtánc-born
/// ward: incoming magic aimed at the shaman is absorbed instead of taking effect, and once enough
/// Mana-worth of magic (30+) has been soaked up, the shaman can unleash it as a crackling lightning
/// vortex that hits everyone within 15 meters for 3D10 SP, scaling further with more absorbed
/// power. Only the base 3D10 discharge is modeled here; the absorption mechanic and its further
/// +1D10-per-10-Mp scaling are not simulated. Mana cost is 31 Mp + 16 FP, fully modeled via
/// ManaCost/PainTolerancePointCost.
/// </summary>
public sealed class StormShield : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Storm shield";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 31;

    public int PainTolerancePointCost => 16;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 18;

    [DiceThrow(ThrowType._3D10)]
    public int GetDamage() => diceThrow._3D10();
}
