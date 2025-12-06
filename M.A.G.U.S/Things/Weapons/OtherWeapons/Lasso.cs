using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Lasso : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1/3;

    public int InitiatingValue => 0;

    public int AttackingValue => 1;

    public int DefendingValue => 0;

    public override double Weight => 0.6;

    public override Money Price => new(0, 0, 80);

    public override int GetDamage() => 0;

    public override string Description => "A long loop of rope thrown to capture or restrain a fleeing beast or man, common among herdsmen and southern riders.";
}