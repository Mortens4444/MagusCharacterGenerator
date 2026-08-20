using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Bátorság dala (Bárd — Dalmágia, Első Törvénykönyv p.136). Raises the fighting spirit of allies
/// within 10 láb who hear the song (KÉ +5, TÉ +15). Cast over allies, not an attack, so it deals
/// no damage and isn't wired into the enemy-targeting combat pipeline, matching how Blessing.cs
/// (Priest) handles ally buffs.
/// </summary>
public sealed class CourageSong : ISpell
{
    public string Name => "Courage song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
