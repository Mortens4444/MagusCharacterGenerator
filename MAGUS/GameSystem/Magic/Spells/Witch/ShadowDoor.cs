using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Árnyékajtó (Boszorkány — Térmágia, Első Törvénykönyv p.230). Opens a short dark corridor
/// connecting two known locations, letting a group walk between them without traveling the
/// distance.
/// </summary>
public sealed class ShadowDoor : ISpell
{
    public string Name => "Shadow door";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 40;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
