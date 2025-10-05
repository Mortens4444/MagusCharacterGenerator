using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class WaterOfLife : MagicalObject
{
    public override string Name => "Water of Life";

    public override Money Price => new(16);

    public override int ManaPoints => 200;

    public override IEnumerable<Class> AllowedCreators => [new Witch()];
}
