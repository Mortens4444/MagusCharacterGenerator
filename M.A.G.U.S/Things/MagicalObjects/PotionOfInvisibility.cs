using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfInvisibility : MagicalObject
{
    public override string Name => "Potion of Invisibility";

    public override Money Price => new(3);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
