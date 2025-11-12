using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class BattleAx : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 5;

    public byte AttackingValue => 11;

    public byte DefendingValue => 8;

    public override double Weight => 2.5;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1K10)]
    public byte GetDamage() => (byte)DiceThrow._1K10();

    public override string Name => "Battle pick";
}