using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.StabbingWeapons;

public class Saber : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 7;

    public int AttackValue => 15;

    public int DefenseValue => 17;

    public override double Weight => 1.5;

    public override Money Price => new(1, 6);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Name => "Sword, sabre";

    public override string Description => "A curved, single-edged sword primarily used for cutting and slashing, often favoured by light cavalry and skilled duelists.";
}