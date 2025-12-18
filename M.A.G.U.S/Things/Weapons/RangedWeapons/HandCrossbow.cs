using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class HandCrossbow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiatingValue => 3;

    public int AimingValue => 14;

    public int Distance => 30;

    public override double Weight => 2;

    public override Money Price => new(20);

    [DiceThrow(ThrowType._1D3_Ranged)]
    public override int GetDamage() => DiceThrow._1D3_RangedAttack();

    public override string Name => "Hand crossbow";

    public override string Description => "A small, easily concealed crossbow, capable of being fired with one hand. Ideal for nobles, rogues, or those needing a surprise ranged attack.";
}