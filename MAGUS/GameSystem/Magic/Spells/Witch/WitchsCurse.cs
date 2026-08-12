using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

public sealed class WitchsCurse : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Witch's curse";

    public MagicSchool School => MagicSchool.Witch;

    public int InitiateValue => 25;

    public int ManaCost => 5;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    /// <summary>The curse bites once on a successful cast, then keeps draining the victim for 2 more rounds.</summary>
    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D4)]
    public int GetDamage() => diceThrow._1D4();
}
