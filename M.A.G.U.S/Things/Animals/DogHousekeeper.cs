using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class DogHousekeeper : Thing
{
    public override string Name => "Dog, guard";

    public override Money Price => new(0, 0, 80);
}
