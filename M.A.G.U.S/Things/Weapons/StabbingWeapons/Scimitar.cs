using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Scimitar : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 6;

    public int AttackValue => 14;

    public int DefenseValue => 15;

    public override double Weight => 2;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D6() + 3;

    public override string Name => "Sword, scimitar";

    public override string Description => "A deeply curved, single-edged blade from the Southern realms, designed to maximize cutting power and commonly associated with desert warriors.";
}