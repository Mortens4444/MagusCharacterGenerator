using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class JadJambiya : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 10;

    public int AttackValue => 12;

    public int DefenseValue => 15;

    public override double Weight => 0.8;

    public override Money Price => new(60);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Jad jambiya";

    public override string Description => "A curved, double-edged dagger from the desert lands of Jad, often worn openly as a symbol of status and used for fierce, close-in fighting.";
}