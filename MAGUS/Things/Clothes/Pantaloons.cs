using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Pantaloons : Thing
{
	public override Money Price => new(0, 0, 150);

    public override string Description => "Loose, somewhat baggy breeches gathered tightly at the ankle or calf. A style often seen in warmer climes or among travelling merchants.";
}
