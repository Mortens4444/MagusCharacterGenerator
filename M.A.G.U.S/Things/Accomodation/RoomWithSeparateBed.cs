using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomWithSeparateBed : Thing
{
	public override string Name => "Room, separate bed";

    public override Money Price => new(0, 0, 5);

    public override string Description => "Private Twin Room\r\n\r\nThe Companion's Retreat. A simple yet private room containing two separate beds. Ideal for those travelling with a companion, family member, or trusted guard who value their own space and undisturbed sleep away from the noise of the common hall.";
}
