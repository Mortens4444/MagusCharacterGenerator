using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class FightingDog : Thing
{
    public override string Name => "Dog, fighting";

    public override Money Price => new(0, 8, 0);
}
