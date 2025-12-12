using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;

namespace M.A.G.U.S.Things.MagicalObjects;

public abstract class MagicalObject : Thing
{
    public abstract int ManaPoints { get; }

    public virtual IEnumerable<Class> AllowedCreators => [new Wizard(), new KrannishWarlock()];
}