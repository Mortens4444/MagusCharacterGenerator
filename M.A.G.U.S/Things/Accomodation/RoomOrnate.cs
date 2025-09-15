using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomOrnate : Thing
{
    public override string Name => "Room, ornate";

    public Money Price => new(0, 0, 10);
}
