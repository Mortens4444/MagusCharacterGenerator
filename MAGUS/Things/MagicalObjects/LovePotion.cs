using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class LovePotion : MagicalObject
{
    public override string Name => "Love Potion";

    public override Money Price => new(5);

    public override int ManaPoints => 45;

    public override IEnumerable<Class> AllowedCreators => [new Witch()];
}
