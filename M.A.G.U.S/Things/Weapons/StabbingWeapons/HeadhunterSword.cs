using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class HeadhunterSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 8;

    public int AttackingValue => 16;

    public int DefendingValue => 16;

    public override double Weight => 0.8;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Name => "Assassin’s sword";

    public override string Description => "A heavy, curved blade with a distinctive, often jagged edge, favoured by tribal warriors for its ability to decapitate foes cleanly.";
}