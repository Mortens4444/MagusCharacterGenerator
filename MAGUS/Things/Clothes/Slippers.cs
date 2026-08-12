using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Slippers : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "Soft, low shoes made of light material or padded leather. Reserved strictly for indoor comfort, offering no protection outside the walls of the home.";
}
