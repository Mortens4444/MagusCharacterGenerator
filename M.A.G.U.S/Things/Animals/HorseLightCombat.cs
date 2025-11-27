using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorseLightCombat : Thing
{
	public override string Name => "Horse, light war";

	public override Money Price => new(3, 0, 0);

    public override string Description => "A nimble war-steed, often used by archers or skirmishers. It possesses good speed and courage but lacks the massive bulk required to fully withstand a charge from heavier cavalry.";
}
