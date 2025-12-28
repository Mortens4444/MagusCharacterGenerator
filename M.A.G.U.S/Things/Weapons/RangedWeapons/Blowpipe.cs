using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class Blowpipe : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 3;

    public int InitiateValue => 8;

    public int AimValue => 7;

    public int Distance => 30;

    public override double Weight => 0.2;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1D1)]
    public override int GetDamage() => DiceThrow._1D1();

    public override string Description => "A simple, slender tube used to silently launch small, often poisoned, darts. A weapon of ambush and subtle execution.";
}