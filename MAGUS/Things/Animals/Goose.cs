using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class Goose : Thing
{
	public override Money Price => new(0, 0, 7);

    public override string Description => "A loud, territorial water-fowl, often kept as a natural guard due to its fierce hiss and warning calls. Its flesh is considered a richer feast than chicken.";
}
