using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Knife : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiateValue => 10;

    public int AttackValue => 4;

    public int DefenseValue => 0;

    public override double Weight => 0.2;

    public override Money Price => new(0, 0, 50);

    [DiceThrow(ThrowType._1D5)]
    public override int GetDamage() => DiceThrow._1D5();

    public override string Description => "A small, utilitarian blade used for carving, skinning, preparing food, and other common tasks. Every man should carry one.";
}