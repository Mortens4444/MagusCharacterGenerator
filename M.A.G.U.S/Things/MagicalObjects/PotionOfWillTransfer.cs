using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfWillTransfer : MagicalObject
{
    public override string Name => "Potion of Will Transfer";

    public override Money Price => new(4);

    public override int ManaPoints => 100;

    public override IEnumerable<Class> AllowedCreators => [new Warlock()];
}
