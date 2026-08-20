using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Engedelmesség - állat (Sámán — Szabad mágia, Második Törvénykönyv p.121). Forces an animal
/// within a 20 meter radius to obey simple commands for the duration; can be boosted (+6 Mp/+1 FP)
/// to let the shaman direct the animal into combat. Mana cost is the base Mp component only (book
/// also asks 6 FP). This codebase has no animal-charm/command subsystem; this class exists only as
/// a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class AnimalObedience : ISpell
{
    public string Name => "Animal obedience";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => 1;

    public int ManaCost => 12;

    public int PainTolerancePointCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 10;

    public int GetDamage() => 0;
}
