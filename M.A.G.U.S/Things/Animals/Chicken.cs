using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Chicken : Thing
{
    public override Money Price => new(0, 0, 5);

    public override string Description => "The most common fowl, kept for their eggs and meagre meat. They scratch about the yards of common folk and are often the cheapest food source available.";
}
