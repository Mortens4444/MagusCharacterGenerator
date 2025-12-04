using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Knife : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 10;

    public byte AttackingValue => 4;

    public byte DefendingValue => 0;

    public override double Weight => 0.2;

    public override Money Price => new(0, 0, 50);

    [DiceThrow(ThrowType._1D5)]
    public byte GetDamage() => (byte)DiceThrow._1D5();

    public override string Description => "A small, utilitarian blade used for carving, skinning, preparing food, and other common tasks. Every man should carry one.";
}