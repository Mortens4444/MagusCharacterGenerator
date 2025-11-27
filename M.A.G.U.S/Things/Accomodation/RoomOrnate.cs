using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class RoomOrnate : Thing
{
    public override string Name => "Room, ornate";

    public override Money Price => new(0, 0, 10);

    public override string Description => "Ornate Chamber\r\n\r\nThe Noble's Rest. A lavishly appointed chamber befitting a Lord or wealthy merchant. It boasts a feather-stuffed mattress, fine woven tapestries upon the walls, and a carved, sturdy wardrobe. Oil lamps of superior quality cast a bright glow, and a dedicated manservant may be near at hand.";
}
