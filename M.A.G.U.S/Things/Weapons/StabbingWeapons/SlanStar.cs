using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SlanStar : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 3;

    public int InitiatingValue => 10;

    public int AttackingValue => 4;

    public int DefendingValue => 4;

    public override double Weight => 0.1;

    public override Money Price => new(0, 0, 40);

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override string Name => "Slan star";

    public override string Description => "A traditional throwing weapon used by Slan warriors. Forged for accuracy and silent strikes, the Slan star is designed to be launched in fluid motion, complementing the Slan’s disciplined combat style. It serves both as a distraction tool and a lethal ranged option.";
}