using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class ChainMace : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 4;

    public int AttackValue => 13;

    public int DefenseValue => 11;

    public override double Weight => 2;

    public override Money Price => new(1, 2);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(3)]
    public override int GetDamage() => DiceThrow._1D6() + 3;

    public override string Name => "Flail with chain";

    public override string Description => "A formidable weapon where a heavy, spiked metal head is affixed to the handle by a length of sturdy chain. It strikes with great, unpredictable force, capable of crushing plate armour.";
}