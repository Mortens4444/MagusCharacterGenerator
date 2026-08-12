using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfWillTransfer : MagicalObject
{
    public override string Name => "Potion of Will Transfer";

    public override Money Price => new(4);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Warlock()];
}
