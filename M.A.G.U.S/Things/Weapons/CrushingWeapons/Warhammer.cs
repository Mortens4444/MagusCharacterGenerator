using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class Warhammer : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 5;

    public int AttackValue => 10;

    public int DefenseValue => 8;

    public override double Weight => 3;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Description => "A weapon designed to defeat armour, featuring a heavy blunt head for crushing and a long, slender spike on the reverse for piercing plates.";
}