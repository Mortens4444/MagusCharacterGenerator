using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzteremtés (Tűzvarázsló, Első Törvénykönyv p.271). Conjures a campfire-sized flame that
/// ignites flammable objects nearby. Fire-school damage bypasses magic resistance entirely per
/// the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireCreation : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire creation";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
