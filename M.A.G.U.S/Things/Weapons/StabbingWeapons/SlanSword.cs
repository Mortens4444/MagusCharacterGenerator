using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SlanSword : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 8;

    public int AttackingValue => 20;

    public int DefendingValue => 12;

    public override double Weight => 1.4;

    public override Money Price => new(100);

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10() + 2;

    public override string Name => "Slan sword";

    public override string Description => "A long, curved weapon resembling a katana, crafted for the graceful but deadly fighting techniques of the Slan. Its flexible steel and razor-sharp edge make it ideal for sweeping cuts, rapid combinations, and the signature flowing movements characteristic of Slan swordmasters.";
}