using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.Spears;

public class Javelin : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 8;

    public int AttackValue => 13;

    public int DefenseValue => 5;

    public override double Weight => 1.5;

    public override Money Price => new(0, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Spear/javelin";

    public override string Description => "A light, slender throwing spear designed to be cast at the foe before closing to melee. Easily carried in a sheaf and effective against unarmoured targets.";
}