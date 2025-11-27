using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class SingleRoom : Thing
{
	public override string Name => "Room, single";

	public override Money Price => new(0, 0, 7);

    public override string Description => "Hermit's Cell\r\n\r\nThe Solitary Haven. A small chamber offering but one simple, narrow bed for a single person. It is modest but clean, and the door may be barred against intrusion. A sanctuary for those seeking utter silence and privacy after a long journey.";
}
