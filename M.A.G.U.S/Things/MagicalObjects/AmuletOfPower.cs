using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfPower : MagicalObject
{
    public override string Name => "Amulet of Power";

    public override Money Price => new(0, 2);

    public override int ManaPoints => 1;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
