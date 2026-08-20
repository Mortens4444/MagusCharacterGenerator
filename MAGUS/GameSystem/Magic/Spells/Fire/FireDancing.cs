using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűztáncoltatás (Tűzvarázsló, Első Törvénykönyv p.271). Lets the caster resize and redirect
/// natural fires within their zone. Fire-school damage bypasses magic resistance entirely per
/// the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireDancing : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire dancing";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
