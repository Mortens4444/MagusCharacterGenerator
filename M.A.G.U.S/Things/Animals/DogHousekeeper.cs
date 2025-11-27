using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class DogHousekeeper : Thing
{
    public override string Name => "Dog, guard";

    public override Money Price => new(0, 0, 80);

    public override string Description => "A loyal kennel dog kept for the purpose of guarding the home and the master's family. They bark fiercely at strangers and possess a keen nose for danger.";
}
