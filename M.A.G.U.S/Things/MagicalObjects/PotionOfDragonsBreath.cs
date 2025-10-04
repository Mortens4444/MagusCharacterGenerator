using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfDragonsBreath : MagicalObject
{
    public override string Name => "Potion of Dragon’s Breath";

    public override Money Price => new(3);
}
