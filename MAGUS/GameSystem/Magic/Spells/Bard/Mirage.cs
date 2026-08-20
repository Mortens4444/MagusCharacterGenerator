using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Délibáb (Bárd — Fénymágia, Első Törvénykönyv p.144). Like Illúzió talaj but vertical — projects
/// a huge backdrop (up to the whole horizon) of any natural scene, city, clouds, or sun, best
/// viewed from 1-2 mérföld away since it has no real depth. Can be raised up to 5 mérföld out.
/// </summary>
public sealed class Mirage : ISpell
{
    public string Name => "Mirage";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
