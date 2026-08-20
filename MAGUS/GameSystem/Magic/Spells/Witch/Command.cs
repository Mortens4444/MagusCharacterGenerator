using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Parancs (Boszorkány — Mentálmágia, Első Törvénykönyv p.217). A one-word command the target
/// must obey for 1 round if they understand the language it was spoken in and fail a Mental
/// resistance roll.
/// </summary>
public sealed class Command : ISpell
{
    public string Name => "Command";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
