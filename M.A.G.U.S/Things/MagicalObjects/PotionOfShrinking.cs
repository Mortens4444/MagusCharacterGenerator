using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfShrinking : MagicalObject
{
    public override string Name => "Potion of Shrinking";

    public override Money Price => new(1);

    public override int ManaPoints => 80;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
