using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class SlanDagger : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 2;

    public int InitiateValue => 9;

    public int AttackValue => 14;

    public int DefenseValue => 6;

    public override double Weight => 0.8;

    public override Money Price => new(70);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._1D6() + 2;

    public override string Name => "Slan dagger";

    public override string Description => "A finely crafted blade favored by Slan martial artists. Its slender shape allows for swift, precise strikes, often used to disable an opponent before they can react. The dagger is balanced for both close-quarters combat and agile defensive maneuvers.";
}