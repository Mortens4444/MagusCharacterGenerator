using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class BootsOfLeaping : MagicalObject
{
    public override string Name => "Boots of Leaping";

    public override Money Price => new(2);

    public override int ManaPoints => 43;
}
