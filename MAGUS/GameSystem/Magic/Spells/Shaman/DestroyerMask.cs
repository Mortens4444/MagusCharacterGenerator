using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Pusztítómaszk (Sámán — Maszkmágia, Második Törvénykönyv p.135-136). A silver mask depicting a
/// melting human face, the darkest of the mask arts. Once empowered (30 Mp + 10 FP per the book's
/// stat block; recharging the mask itself afterward costs a separate 70 Mp + 1 FP "Felruházás",
/// not modeled), it drains 4D10 FP once from every marked victim within 10 meters (every 4 FP lost
/// has a 50% chance to also cost 1 ÉP, not modeled; armor SFÉ does not protect against it).
/// </summary>
public sealed class DestroyerMask : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Destroyer mask";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 30;

    public int PainTolerancePointCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 2;

    [DiceThrow(ThrowType._4D10)]
    public int GetDamage() => diceThrow._4D10();
}
