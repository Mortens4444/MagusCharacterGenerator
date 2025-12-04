using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class HandCrossbow : Weapon, IRangedWeapon
{
    public double AttacksPerRound => 2;

    public byte InitiatingValue => 3;

    public byte AimingValue => 14;

    public ushort Distance => 30;

    public override double Weight => 2;

    public override Money Price => new(20);

    [DiceThrow(ThrowType._1D3)]
    public byte GetDamage() => (byte)DiceThrow._1D3_RangedAttack();

    public override string Name => "Hand crossbow";

    public override string Description => "A small, easily concealed crossbow, capable of being fired with one hand. Ideal for nobles, rogues, or those needing a surprise ranged attack.";
}