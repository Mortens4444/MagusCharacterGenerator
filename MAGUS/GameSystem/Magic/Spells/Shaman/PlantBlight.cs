using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Növényi kórság (Sámán, Második Törvénykönyv p.111-112, Ráolvasások — Területre ható átkok).
/// Infects plants only with a spreading magical blight: leaves yellow and wilt, and the year's
/// crop fails, though the plants themselves survive. Spreads 1-5 m/week (KM's call) unless it runs
/// out of plants to reach, and is undone by a shaman's or priest's Átokűzés or by burning the
/// blighted field. Area is 25 + caster level meters radius, level-1 baseline used (not
/// level-scaled). Book duration is "Maradandó" (lasting); approximated here as a long but finite
/// value. This codebase has no crop/agriculture-blight subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class PlantBlight : ISpell
{
    public string Name => "Plant blight";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 300;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
