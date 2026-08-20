using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fókuszált fény (Bárd — Fénymágia, Első Törvénykönyv p.143). One of the few Bard spells with
/// direct damage — focuses ambient light into a single scorching point the bard can steer, dealing
/// 3D6 Sp per round to living creatures (and vaporizing thin non-magical metal). Duration is
/// kör/3szint in the book; level-1 baseline (1 round) shown, not level-scaled.
/// </summary>
public sealed class FocusedLight : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Focused light";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._3D6)]
    public int GetDamage() => diceThrow._3D6();
}
