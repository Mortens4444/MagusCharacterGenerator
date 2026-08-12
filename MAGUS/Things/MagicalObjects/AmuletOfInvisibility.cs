using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class AmuletOfInvisibility : MagicalObject
{
    public override string Name => "Amulet of Invisibility";

    public override Money Price => new(0, 4);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Warlock()];
}
