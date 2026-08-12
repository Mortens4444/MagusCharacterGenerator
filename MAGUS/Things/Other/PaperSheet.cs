using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class PaperSheet : Thing
{
	public override string Name => "Paper, sheet";

	public override Money Price => new(0, 0, 20);

    public override string Description => "A single, thin sheet of processed pulp, used for writing. Far more costly than vellum, it is primarily used for quick notes or common documents.";
}
