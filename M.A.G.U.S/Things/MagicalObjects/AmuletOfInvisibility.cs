using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfInvisibility : MagicalObject
{
    public override string Name => "Amulet of Invisibility";

    public override Money Price => new(0, 4);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Warlock()];
}
