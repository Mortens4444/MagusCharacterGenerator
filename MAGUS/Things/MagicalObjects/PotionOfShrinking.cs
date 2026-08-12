using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfShrinking : MagicalObject
{
    public override string Name => "Potion of Shrinking";

    public override Money Price => new(1);

    public override int ManaPoints => 80;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
