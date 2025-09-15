using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomSharedBedroom : Thing
{
    public override string Name => "Room, shared bedroom";

    public Money Price => new(0, 0, 2);
}
