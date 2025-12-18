using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class TwoHandedHatchet : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1 / 2;

    public int InitiateValue => 0;

    public int AttackValue => 8;

    public int DefenseValue => 6;

    public override double Weight => 5;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._3D6)]
    public override int GetDamage() => DiceThrow._3D6();

    public override string Name => "Two-handed axe";

    public override string Description => "A heavy axe requiring both hands, used to split wood and foes alike. A weapon of pure destructive force.";
}