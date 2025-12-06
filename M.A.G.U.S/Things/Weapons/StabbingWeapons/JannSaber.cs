using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class JannSaber : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 9;

    public int AttackingValue => 20;

    public int DefendingValue => 17;

    public override double Weight => 120;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D6() + 3;

    public override string Name => "Sword, jann sabre";

    public override string Description => "A long, elegantly curved sabre used by the Jann desert warriors. Its balance and edge are optimized for deadly sweeping cuts from horseback.";
}