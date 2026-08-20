using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Életerőszívás (Boszorkánymester — Nekromancia, Első Törvénykönyv p.258). Book also converts
/// every 6 Fp drained into 1 additional Ép loss and halves the victim's future healing rate;
/// neither secondary effect is modeled here.
/// </summary>
public sealed class DrainLifeForce : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Drain life force";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D10)]
    public int GetDamage() => diceThrow._2D10();
}
