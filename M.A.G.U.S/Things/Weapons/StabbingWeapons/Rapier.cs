using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Rapier : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 9;

    public int AttackValue => 12;

    public int DefenseValue => 14;

    public override double Weight => 0.8;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Description => "A very thin, elegant thrusting sword with a complex hilt to protect the hand. Used by duelists and fencing masters who prize speed and precision over brute force.";
}