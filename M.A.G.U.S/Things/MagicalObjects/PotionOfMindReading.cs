using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfMindReading : MagicalObject
{
    public override string Name => "Potion of Mind Reading";

    public override Money Price => new(5);

    public override int ManaPoints => 60;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
