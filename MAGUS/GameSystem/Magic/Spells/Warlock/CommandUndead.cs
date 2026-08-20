using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Élőholt parancsnoklás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.261). Issues a
/// two-word command in the Tongue of the Dead to a targeted undead. Book: mindless/semi-
/// intelligent undead obey without a resistance roll; intelligent undead get a Mentális magic-
/// resistance roll — Power/ResistanceType here represent that second case only. This codebase has
/// no controllable-undead-minion or creature-summoning system; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class CommandUndead : ISpell
{
    public string Name => "Command undead";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => 5;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
