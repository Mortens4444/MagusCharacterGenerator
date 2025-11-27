using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class GalleonPaddles : Thing
{
	public override string Name => "Galley oar";

	public override Money Price => new(0, 3, 0);

    public override string Description => "Massive oars or sweeps used on the lower decks of a galleon, often manned by shackled prisoners or slaves, to assist in manoeuvring or provide speed when the wind fails.";
}
