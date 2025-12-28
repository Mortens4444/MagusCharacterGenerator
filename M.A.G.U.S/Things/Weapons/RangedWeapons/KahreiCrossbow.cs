using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class KahreiCrossbow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 3;

    public override int InitiateValue => 9;

    public int AimValue => 13;

    public int Distance => 30;

    public override double Weight => 3;

    public override Money Price => new(80);

    [DiceThrow(ThrowType._1D3_Ranged)]
    public override int GetDamage() => DiceThrow._1D3_RangedAttack();

    public override string Name => "Kahrei crossbow";

    public override string Description => "A unique, intricately designed crossbow of Kahrei origin, known for its unique firing mechanism and tendency to favour heavier, specialized bolts.";
}