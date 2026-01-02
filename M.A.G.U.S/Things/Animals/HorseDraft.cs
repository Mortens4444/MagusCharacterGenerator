using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorseDraft : Thing
{
	public override string Name => "Horse, draft";

	public override Money Price => new(0, 8, 0);

    public override string Description => "A sturdy draught horse, specifically trained and broken to wear the yoke for pulling plows or massive waggons. Not bred for speed or grace, but for enduring labour.";
}
