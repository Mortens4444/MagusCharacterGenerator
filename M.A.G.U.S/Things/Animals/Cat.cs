using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Cat : Thing
{
    public override Money Price => new(0, 0, 5);

    public override string Description => "A sly and silent hunter of vermin, kept in homes and granaries to control mice and rats. They require little upkeep and are considered good luck by some.";
}
