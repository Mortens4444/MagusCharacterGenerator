using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class WandOfTravel : MagicalObject
{
    public override string Name => "Wand of Travel";

    public override Money Price => new(0, 2);
}
