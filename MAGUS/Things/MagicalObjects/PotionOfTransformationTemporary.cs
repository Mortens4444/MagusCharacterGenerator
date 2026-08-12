using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfTransformationTemporary : MagicalObject
{
    public override string Name => "Potion of Transformation (Temporary)";

    public override Money Price => new(10);

    public override int ManaPoints => 120;

    public override string[] Images => ["potion_of_transformation.png"];

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
