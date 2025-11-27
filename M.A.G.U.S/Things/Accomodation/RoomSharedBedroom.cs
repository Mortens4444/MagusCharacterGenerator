using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomSharedBedroom : Thing
{
    public override string Name => "Room, common dormitory";

    public override Money Price => new(0, 0, 2);

    public override string Description => "Common Quarters\r\n\r\nThe Travellers' Communal Lair. The most affordable and bustling lodging. Here, many beds are set side-by-side in one great room. Expect loud snoring, questionable smells, and little privacy, but it is warm and guarded from the night's chill. A place for fellowship, or sleepless nights.";
}
