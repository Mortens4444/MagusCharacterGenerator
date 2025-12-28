using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.OtherWeapons;

public class Scourge : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 4;

    public int AttackValue => 6;

    public int DefenseValue => 0;

    public override double Weight => 0.5;

    public override Money Price => new(0, 1, 20);

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override string Description => "A multi-tailed whip, often tipped with lead or sharp metal pieces. Used for painful punishment and torture, or as a terrifying weapon in combat.";
}