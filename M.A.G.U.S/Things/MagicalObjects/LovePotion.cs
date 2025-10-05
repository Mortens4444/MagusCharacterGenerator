using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class LovePotion : MagicalObject
{
    public override string Name => "Love Potion";

    public override Money Price => new(5);

    public override int ManaPoints => 45;

    public override IEnumerable<Class> AllowedCreators => [new Witch()];
}
