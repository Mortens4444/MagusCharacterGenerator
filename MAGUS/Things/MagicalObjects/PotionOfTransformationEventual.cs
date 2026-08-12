using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfTransformationEventual : MagicalObject
{
    public override string Name => "Potion of Transformation (Eventual)";

    public override Money Price => new(28);

    public override int ManaPoints => 240;
    
    public override string[] Images => ["potion_of_transformation.png"];

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
