using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Cat : Thing
{
    public Money Price => new(0, 0, 5);
}
