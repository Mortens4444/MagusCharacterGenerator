using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.CrushingWeapons;

public class Flail : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 1;

    public int AttackValue => 6;

    public int DefenseValue => 5;

    public override double Weight => 2.5;

    public override Money Price => new(0, 7);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Flail (thresher)";

    public override string[] Images => ["flail_thresher.png"];

    public override string Description => "A weapon originally derived from the thresher, featuring a studded or spiked ball linked by a short chain to a wooden handle. Its flexible nature makes it difficult to parry.";
}