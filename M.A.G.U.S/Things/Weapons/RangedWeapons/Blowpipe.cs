using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.AimingWeapons;

public class Blowpipe : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 3;

    public byte InitiatingValue => 8;

    public byte AimingValue => 7;

    public ushort Distance => 30;

    public override double Weight => 0.2;

    public override Money Price => new(0, 6);

    [DiceThrow(ThrowType._1K1)]
    public byte GetDamage()
    {
        if (DiceThrow._1K6() == 6)
        {
            return 1;
        }
        return 0;
    }
}