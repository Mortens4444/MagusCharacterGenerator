using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class LeatherArmor : Thing
{
	public override string Name => "Studded leather";

	public override Money Price => new(0, 4, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 1;

	public override double Weight => 8;

    public override string Description => "Simple armour made from boiled or treated leather hides. Provides basic protection against minor cuts and scrapes, favoured by bandits, hunters, and those who need unrestricted movement.";
}
