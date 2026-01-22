using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Shields;

public class LargeShield : Shield
{
	public override double AttacksPerRound => 1.0 / 2;

    public override int InitiateValue => 0;

	public override int DefenseValue => 50;

	public override int MovementObstructiveFactor => 5;

	public override double Weight => 6;

	public override Money Price => new(6);

	[DiceThrow(ThrowType._1D6)]
	public override int GetDamage() => DiceThrow._1D6();

	public override string Name => "Large shield";

    public override string Description => "A tower of stout wood and leather, often reinforced with bands of iron, extending from the shoulder to the knee. It offers maximum coverage to the wielder, fit for defending a narrow passage or forming a shield wall, though cumbersome in quick combat.";
}