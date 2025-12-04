using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class ElvenBow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 6;

    public byte AimingValue => 10;

    public ushort Distance => 120;

    public override double Weight => 0.7;

    public override Money Price => new(120);

    public byte GetDamage() => (byte)DiceThrow._2D6_RangedAttack();

    public override string Name => "Elven bow";

    public override string Description => "A beautifully crafted longbow made from rare, resilient woods. Its draw is light, yet its arrows fly further and with greater accuracy than common bows.";
}