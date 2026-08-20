using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Gyilkos pára (Sámán — Természeti mágia, Második Törvénykönyv p.127-128). Summons a thick,
/// syrupy, evil-smelling mist (within 25 meters of the shaman) that dazes everyone caught inside
/// (Kábultság rules) and drains 1D10 points per round - Mana/Psi first, then Fájdalomtűrés, then
/// Életerő - piercing even Statikus pajzs. Simplified to a flat 1D10 drain per round with no
/// resistance roll, matching the book's lack of a magic-resistance line.
/// </summary>
public sealed class LethalMist : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lethal mist";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 39;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 2;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
