using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Garrote : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 0;

    public int AttackingValue => 5;

    public int DefendingValue => 0;//-20;

    public override double Weight => 0.1;

    public override Money Price => new(0, 1);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Description => "A loop of wire or fine cord used to strangle a foe silently and quickly. The weapon of assassins and silent killers.";
}