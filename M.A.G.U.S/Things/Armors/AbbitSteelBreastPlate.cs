using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelBreastPlate : Thing
{
	public override string Name => "Abbit-steel breastplate";

	public override Money Price => new(200, 0, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 8;

	public override double Weight => 12;

    public override string Description => "A finely wrought, single piece of Abbit-steel, meticulously hammered to protect the vital organs of the chest. It offers superior frontal defense compared to common steel, albeit at a heavy price.";
}
