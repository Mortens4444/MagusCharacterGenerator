using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class JannSaber : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 9;

    public byte AttackingValue => 20;

    public byte DefendingValue => 17;

    public override double Weight => 120;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 3);

    public override string Name => "Sword, jann sabre";

    public override string Description => "A long, elegantly curved sabre used by the Jann desert warriors. Its balance and edge are optimized for deadly sweeping cuts from horseback.";
}