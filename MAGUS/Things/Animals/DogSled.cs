using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class DogSled : Thing
{
	public override string Name => "Dog, sled";

	public override Money Price => new(0, 0, 120);

    public override string Description => "A stout, thick-furred dog used to pull sledges and carts across frozen, snowy terrain, particularly in the northern reaches. They thrive in harsh, cold climates.";
}
