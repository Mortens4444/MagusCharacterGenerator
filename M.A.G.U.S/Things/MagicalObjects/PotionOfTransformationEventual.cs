using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfTransformationEventual : MagicalObject
{
    public override string Name => "Potion of Transformation (Eventual)";

    public override Money Price => new(28);

    public override int ManaPoints => 240;
    
    public override string[] Images => ["potion_of_transformation.png"];

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
