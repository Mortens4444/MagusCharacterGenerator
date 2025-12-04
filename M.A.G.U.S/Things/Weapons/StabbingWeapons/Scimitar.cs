using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Scimitar : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 6;

    public byte AttackingValue => 14;

    public byte DefendingValue => 15;

    public override double Weight => 2;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 3);

    public override string Name => "Sword, scimitar";

    public override string Description => "A deeply curved, single-edged blade from the Southern realms, designed to maximize cutting power and commonly associated with desert warriors.";
}