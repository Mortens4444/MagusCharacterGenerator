using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Kínok dala (Bárd — Dalmágia, Első Törvénykönyv p.135). Everyone who hears the song and fails
/// their resistance suffers a splitting headache followed by waves of agony, losing hit points
/// every round the song continues. Book cost is 4 Mana-pont per round sustained, and duration
/// lasts as long as the bard keeps singing and has mana; both simplified to a flat
/// ManaCost/DurationInRounds here.
/// </summary>
public sealed class AgonySong : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Agony song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 25;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
