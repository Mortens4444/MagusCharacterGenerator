using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kígyóbűvölés (Boszorkány — Asztrálmágia, Első Törvénykönyv p.210). Places reptiles (snakes,
/// crocodiles) under the witch's simple commands, up to caster-level in number at once. Power is
/// null (book ME "-"). Duration is "15 kör/szint" in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class SnakeCharming : ISpell
{
    public string Name => "Snake charming";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
