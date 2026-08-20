using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Fémizzítás (Tűzvarázsló, Első Törvénykönyv p.279). Egy megjelölt fémtárgyat körönként egyre
/// forróbbá izzít, míg meg nem olvad. Fire-school damage bypasses magic resistance entirely per
/// the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class MetalHeating : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Metal heating";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
