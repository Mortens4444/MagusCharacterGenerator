using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfInvisibility : MagicalObject
{
    public override string Name => "Potion of Invisibility";

    public override Money Price => new(3);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
