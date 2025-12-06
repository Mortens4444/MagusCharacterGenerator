using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class CavalryLance : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1 / 2;

    public int InitiatingValue => 1;

    public int AttackingValue => 15;

    public int DefendingValue => 0;

    public override double Weight => 3.5;

    public override Money Price => new(1);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Cavalry lance";

    public override string Description => "A long, tapering wooden shaft with a sharp head, wielded by a mounted warrior. Designed to deliver a single, devastating charge against a foe.";
}