using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class ThrowingNet : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1 / 3;

    public int InitiateValue => 1;

    public int AttackValue => 8;

    public int DefenseValue => 4;

    public override double Weight => 1;

    public override Money Price => new(0, 3);

    public override int GetDamage() => 0;

    public override string Name => "Throwing net";

    public override string Description => "A weighted, woven net thrown to entangle and immobilize an enemy, allowing the wielder time to close in or escape.";
}