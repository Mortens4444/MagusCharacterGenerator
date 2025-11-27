using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ParchmentSheets : Thing
{
	public override string Name => "Parchment, sheet";

	public override Money Price => new(0, 0, 15);

    public override string Description => "Several pieces of cured animal hide, scraped thin and prepared for writing. Durable and costly, it is used for important scrolls, maps, or magical texts.";
}
