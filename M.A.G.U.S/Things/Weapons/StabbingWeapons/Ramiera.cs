using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Ramiera : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 8;

    public int AttackValue => 17;

    public int DefenseValue => 14;

    public override double Weight => 0.8;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Description => "A long, thin, piercing sword with a sharp point, favoured by those who fight in plate armour and seek the gaps in their opponent's defense.";
}