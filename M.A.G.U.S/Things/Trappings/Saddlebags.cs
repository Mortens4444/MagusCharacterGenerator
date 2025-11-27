using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class Saddlebags : Thing
{
	public override Money Price => new(0, 1, 0);

    public override string Description => "Two large pouches of leather or canvas connected by straps, designed to hang across the horse's back behind the saddle. Used to carry provisions and small gear.";
}
