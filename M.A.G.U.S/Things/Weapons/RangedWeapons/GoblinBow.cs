using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class GoblinBow : Weapon, IRangedWeapon, INotForSale
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 5;

    public int AimValue => 2;

    public int Distance => 60;

    public override double Weight => 0.6;

    public override Money Price => new(3);

    [DiceThrow(ThrowType._1D5_Ranged)]
    public override int GetDamage() => DiceThrow._1D5_RangedAttack();

    public override string Description => "Goblin-crafted bow, which cannot compete with those made by human or elven hands.";
}