using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class CavalryLance : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1.0 / 2;

    public override int InitiateValue => 1;

    public int AttackValue => 15;

    public int DefenseValue => 0;

    public override double Weight => 3.5;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Cavalry lance";

    public override string Description => "A long, tapering wooden shaft with a sharp head, wielded by a mounted warrior. Designed to deliver a single, devastating charge against a foe.";
}