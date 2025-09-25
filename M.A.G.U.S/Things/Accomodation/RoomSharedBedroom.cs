using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomSharedBedroom : Thing
{
    public override string Name => "Room, common dormitory";

    public override Money Price => new(0, 0, 2);
}
