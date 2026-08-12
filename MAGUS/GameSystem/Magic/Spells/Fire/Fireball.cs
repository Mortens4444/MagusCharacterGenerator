using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

public sealed class Fireball : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fireball";

    public MagicSchool School => MagicSchool.Fire;

    public int InitiateValue => 35;

    public int ManaCost => 6;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._3D6)]
    public int GetDamage() => diceThrow._3D6();
}
