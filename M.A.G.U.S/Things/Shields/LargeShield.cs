using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Shields;

public class LargeShield : Shield
{
	public double AttacksPerRound => 1 / 2;

	public byte InitiatingValue => 0;

	public byte DefendingValue => 50;

	public byte MovementObstructiveFactor => 5;

	public override double Weight => 6;

	public override Money Price => new(6);

	[DiceThrow(ThrowType._1K6)]
	public byte GetDamage() => (byte)DiceThrow._1K6();

	public override string Name => "Large shield";

    public override string Description => "A tower of stout wood and leather, often reinforced with bands of iron, extending from the shoulder to the knee. It offers maximum coverage to the wielder, fit for defending a narrow passage or forming a shield wall, though cumbersome in quick combat.";
}