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

	public double Weight => 6;

	public Money Price => new(6);

	[DiceThrow(ThrowType._1K6)]
	public byte GetDamage() => (byte)DiceThrow._1K6();

	public override string Name => "Large shield";
}