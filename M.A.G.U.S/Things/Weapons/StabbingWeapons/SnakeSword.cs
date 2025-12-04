using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SnakeSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 6;

    public byte AttackingValue => 14;

    public byte DefendingValue => 15;

    public override double Weight => 1.4;

    public override Money Price => new(6);

    [DiceThrow(ThrowType._1D10)]
    public byte GetDamage() => (byte)DiceThrow._1D10();

    public override string Name => "Snake sword";

    public override string Description => "A thin, highly flexible sword whose blade appears to writhe and flow like a serpent, capable of delivering unexpected cuts and disarms.";
}