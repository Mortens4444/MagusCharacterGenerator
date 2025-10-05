using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class GlovesOfStrength : MagicalObject
{
    public override string Name => "Gloves of Strength";

    public override Money Price => new(3);

    public override int ManaPoints => 73;
}
