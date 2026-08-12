using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfFlight : MagicalObject
{
    public override string Name => "Potion of Flight";

    public override Money Price => new(2);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
