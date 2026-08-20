using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Lángszórás (Tűzvarázsló, Első Törvénykönyv p.274). Fire-jets erupt from the caster's fingers
/// in a fan-shaped spray (up to a 60-degree angle, 10 láb reach), damaging and igniting everyone
/// they touch. Fire-school damage bypasses magic resistance entirely per the rulebook (p.267),
/// hence Power is null.
/// </summary>
public sealed class FlameSpray : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Flame spray";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 7;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
