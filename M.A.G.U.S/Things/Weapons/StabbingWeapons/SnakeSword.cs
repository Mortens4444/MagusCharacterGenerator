using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SnakeSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 6;

    public int AttackingValue => 14;

    public int DefendingValue => 15;

    public override double Weight => 1.4;

    public override Money Price => new(6);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Name => "Snake sword";

    public override string Description => "A thin, highly flexible sword whose blade appears to writhe and flow like a serpent, capable of delivering unexpected cuts and disarms.";
}