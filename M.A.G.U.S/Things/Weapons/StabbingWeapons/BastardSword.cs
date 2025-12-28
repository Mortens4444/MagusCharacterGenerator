using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class BastardSword : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 4;

    public int AttackValue => 13;

    public int DefenseValue => 12;

    public override double Weight => 2;

    public override Money Price => new(2, 5);

    [DiceThrow(ThrowType._2D6)]
    public override int GetDamage() => DiceThrow._2D6();

    public override string Name => "Bastard sword";

    public override string Description => "A sword of intermediate size, too large for one hand but light enough to be wielded with one hand and a shield by a strong man. The 'hand-and-a-half' sword.";
}