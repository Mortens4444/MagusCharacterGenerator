using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class BattleAxe : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 5;

    public int AttackValue => 11;

    public int DefenseValue => 8;

    public override double Weight => 2.5;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override string Name => "Battle pick";

    public override string Description => "A heavy-bladed axe with a long handle, designed for chopping through shields, mail, and flesh with crushing force.";
}