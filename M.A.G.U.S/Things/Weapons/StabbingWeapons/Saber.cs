using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Saber : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 7;

    public byte AttackingValue => 15;

    public byte DefendingValue => 17;

    public override double Weight => 1.5;

    public override Money Price => new(1, 6);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 2);

    public override string Name => "Sword, sabre";

    public override string Description => "A curved, single-edged sword primarily used for cutting and slashing, often favoured by light cavalry and skilled duelists.";
}