using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class BattleAx : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 5;

    public int AttackingValue => 11;

    public int DefendingValue => 8;

    public override double Weight => 2.5;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Name => "Battle pick";

    public override string Description => "A heavy-bladed axe with a long handle, designed for chopping through shields, mail, and flesh with crushing force.";
}