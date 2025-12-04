using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class KahreiCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 3;

    public byte InitiatingValue => 9;

    public byte AimingValue => 13;

    public ushort Distance => 30;

    public override double Weight => 3;

    public override Money Price => new(80);

    [DiceThrow(ThrowType._1D3)]
    public byte GetDamage() => (byte)DiceThrow._1D3_RangedAttack();

    public override string Name => "Kahrei crossbow";

    public override string Description => "A unique, intricately designed crossbow of Kahrei origin, known for its unique firing mechanism and tendency to favour heavier, specialized bolts.";
}