using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Camel : Thing
{
    public override Money Price => new(1, 0, 0);

    public override string Description => "A ship of the desert, capable of carrying great weights across vast, arid wastes with little need for water. A common sight only in the markets of the Southern Lands.";
}
