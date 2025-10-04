using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfTransformationTemporary : MagicalObject
{
    public override string Name => "Potion of Transformation (Temporary)";

    public override Money Price => new(10);
}
