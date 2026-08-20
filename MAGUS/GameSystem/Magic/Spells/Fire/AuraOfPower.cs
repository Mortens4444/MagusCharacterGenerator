using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Hatalomaura (Tűzvarázsló, Első Törvénykönyv p.279-280). Szinte megegyezik a Tűzaurával,
/// csak az aura nem a testtől 5-10 centiméterre, hanem attól távolabb öleli körül a
/// tűzvarázslót. Fire-school damage bypasses magic resistance entirely per the rulebook
/// (p.267), hence Power is null.
/// </summary>
public sealed class AuraOfPower : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Aura of power";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 2;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
