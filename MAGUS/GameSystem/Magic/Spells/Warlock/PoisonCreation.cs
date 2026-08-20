using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Méregvarázs (Boszorkánymester — Méregmágia, Első Törvénykönyv p.252). Imbues any liquid with
/// poisonous properties, undetectable by taste, color, or smell. Casting time is kör/méreg
/// szintje (rounds per poison level) in the book; level-1 baseline shown. Doesn't deliver the
/// poison to a victim on its own — that requires a separate delivery method.
/// </summary>
public sealed class PoisonCreation : ISpell
{
    public string Name => "Poison creation";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
