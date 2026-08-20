using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzszőnyeg (Tűzvarázsló, Első Törvénykönyv p.273). One of the fire school's six basic forms:
/// carpets a 5-lépés-radius area with knee-high flames, damaging anyone who enters or stands in
/// it each round and igniting flammables it touches. Fire-school damage bypasses magic
/// resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireCarpet : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire carpet";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
