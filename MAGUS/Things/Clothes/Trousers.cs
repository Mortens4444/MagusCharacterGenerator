using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Trousers : Thing
{
	public override Money Price => new(0, 0, 3);

    public override string Name => "Trousers (peasant)";

    public override string[] Images => ["trousers_peasant.png"];

    public override string Description => "Leg coverings differing from pants by often being more tightly fitted or tailored. Worn by soldiers and those who require freedom of movement in their lower limbs.";
}
