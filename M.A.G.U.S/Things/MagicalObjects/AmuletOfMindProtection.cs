using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfMindProtection : MagicalObject
{
    public override string Name => "Amulet of Mind Protection";

    public override Money Price => new(0, 2);
}
