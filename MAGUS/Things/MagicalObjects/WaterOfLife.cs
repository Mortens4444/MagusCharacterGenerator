using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class WaterOfLife : MagicalObject
{
    public override string Name => "Water of Life";

    public override Money Price => new(16);

    public override int ManaPoints => 200;

    public override IEnumerable<Class> AllowedCreators => [new Witch()];
}
