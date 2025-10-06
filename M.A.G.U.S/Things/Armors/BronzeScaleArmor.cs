using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeScaleArmor : Thing
{
    public override string Name => "Bronze scale armor";

    public override Money Price => new(16, 0, 0);

    public int MovementInhibitingFactor => -2;

    public int DamageSusceptiveValue => 2;

    public override double Weight => 18;
}
