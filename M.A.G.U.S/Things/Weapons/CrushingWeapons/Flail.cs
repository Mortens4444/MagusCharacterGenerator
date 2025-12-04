using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class Flail : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 1;

    public byte AttackingValue => 6;

    public byte DefendingValue => 5;

    public override double Weight => 2.5;

    public override Money Price => new(0, 7);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 1);

    public override string Name => "Flail (thresher)";

    public override string Description => "A weapon originally derived from the thresher, featuring a studded or spiked ball linked by a short chain to a wooden handle. Its flexible nature makes it difficult to parry.";
}