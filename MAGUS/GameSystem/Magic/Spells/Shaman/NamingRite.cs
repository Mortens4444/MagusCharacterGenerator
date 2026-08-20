using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Névadás (Sámán, Második Törvénykönyv p.109). The naming ritual by which a nomad child (or
/// convert) receives their true, spirit-protected name; the book states it has no stat block of
/// its own and is literally just an Áldozat (sacrifice, 3 Mp + 1 FP, 23 perc/138 kör) immediately
/// followed by a Felruházás (empowerment, 7 Mp + 1 FP, 1 kör + 3 kör). Without a true name a
/// nomad has no guardian spirit and no Astral/Mental protection; the named person's guardian
/// spirit can also be invoked, for good or ill, by anyone who knows their true name. ManaCost
/// (10), CastingTimeInSegments (1420), and PainTolerancePointCost (2) here are the sum of the two
/// component rituals' Mp, casting-time, and FP figures (1+1). This codebase has
/// no naming/guardian-spirit subsystem; this class exists only as a spellbook/catalog entry with
/// no simulated mechanical effect.
/// </summary>
public sealed class NamingRite : ISpell
{
    public string Name => "Naming rite";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 10;

    public int PainTolerancePointCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1420;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
