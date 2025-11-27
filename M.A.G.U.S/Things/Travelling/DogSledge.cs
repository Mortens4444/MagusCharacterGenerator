using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class DogSledge : Thing
{
	public override string Name => "Dog sled";

	public override Money Price => new(0, 8, 0);

    public override string Description => "A flat, runner-equipped conveyance built for traversing snow and ice, pulled by a team of strong, cold-weather dogs. Necessary for survival in the deep North.";
}
