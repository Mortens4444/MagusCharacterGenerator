using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Lasso : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1/3;

    public override int InitiateValue => 0;

    public int AttackValue => 1;

    public int DefenseValue => 0;

    public override double Weight => 0.6;

    public override Money Price => new(0, 0, 80);

    public override int GetDamage() => 0;

    public override string Description => "A long loop of rope thrown to capture or restrain a fleeing beast or man, common among herdsmen and southern riders.";
}