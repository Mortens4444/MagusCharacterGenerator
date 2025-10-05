using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfTransformationTemporary : MagicalObject
{
    public override string Name => "Potion of Transformation (Temporary)";

    public override Money Price => new(10);

    public override int ManaPoints => 120;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
