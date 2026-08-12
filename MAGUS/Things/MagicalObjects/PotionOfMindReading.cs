using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfMindReading : MagicalObject
{
    public override string Name => "Potion of Mind Reading";

    public override Money Price => new(5);

    public override int ManaPoints => 60;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
