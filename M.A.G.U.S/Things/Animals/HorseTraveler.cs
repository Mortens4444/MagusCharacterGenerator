using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorseTraveler : Thing
{
	public override string Name => "Horse, traveler";

	public override Money Price => new(1, 0, 0);

    public override string Description => "A common road horse, bred for speed and endurance over long distances. Suitable for messengers, scouts, and merchants who must reach their destination swiftly.";
}
