using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class AmuletOfLuck : MagicalObject
{
    public override string Name => "Amulet of Luck";

    public override Money Price => new(0, 2);

    public override int ManaPoints => 120;

    public override IEnumerable<Class> AllowedCreators => [new Witch()];
}
