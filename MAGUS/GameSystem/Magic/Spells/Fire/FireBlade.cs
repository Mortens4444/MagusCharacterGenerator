using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzpenge (Tűzvarázsló, Első Törvénykönyv p.280). A levegőben lebegő, önálló tűzcsíkot idéz
/// meg, mely körönként egyszer önállóan támad, mint egy láthatatlan harcos. Fire-school damage
/// bypasses magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireBlade : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire blade";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 4;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
