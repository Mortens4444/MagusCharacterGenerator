using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class ChainMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 4;

    public byte AttackingValue => 13;

    public byte DefendingValue => 11;

    public double Weight => 2;

    public override Money Price => new(1, 2);

    [DiceThrow(ThrowType._1K6)]
    [DiceThrowModifier(3)]
    public byte GetDamage() => (byte)(DiceThrow._1K6() + 3);

    public override string Name => "Flail with chain";
}