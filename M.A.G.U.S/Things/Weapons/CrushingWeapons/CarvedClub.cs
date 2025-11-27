using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class CarvedClub : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 2;

    public byte AttackingValue => 7;

    public byte DefendingValue => 14;

    public override double Weight => 1.3;

    public override Money Price => Money.Free;

    [DiceThrow(ThrowType._1K6)]
    public byte GetDamage() => (byte)DiceThrow._1K6();

    public override string Name => "Club";

    public override string Description => "A heavy cudgel of wood, often crudely fashioned but decorated with simple carvings. The common weapon of bandits, peasants, or those with little coin for true steel.";
}