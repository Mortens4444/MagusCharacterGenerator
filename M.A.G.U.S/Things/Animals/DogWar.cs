using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class DogWar : Thing
{
    public override string Name => "Dog, war";

    public override Money Price => new(0, 8, 0);

    public override string Description => "A fierce, heavily muscled war dog, often clad in leather armour, trained only for the purpose of Attack and subduing men in battle or pit fights. Highly aggressive and dangerous.";
}
