using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzkapu (térmágia) (Tűzvarázsló, Első Törvénykönyv p.281-282). A tűzvarázsló és felszerelése
/// egy legalább 3E erősségű tűztől egy másik, legalább ugyanolyan erősségű tűzhöz "teleportál".
/// Deals no damage. Fire-school damage bypasses magic resistance entirely per the rulebook
/// (p.267), hence Power is null.
/// </summary>
public sealed class FireGate : ISpell
{
    public string Name => "Fire gate";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
