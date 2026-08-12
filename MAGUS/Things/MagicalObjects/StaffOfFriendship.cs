using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class StaffOfFriendship : MagicalObject
{
    public override string Name => "Staff of Friendship";

    public override Money Price => new(0, 8);

    public override int ManaPoints => 98;
}
