using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;

namespace MAGUS.Things.MagicalObjects;

public abstract class MagicalObject : Thing
{
    public abstract int ManaPoints { get; }

    public virtual IEnumerable<Class> AllowedCreators => [new Wizard(), new KrannishWarlock()];
}