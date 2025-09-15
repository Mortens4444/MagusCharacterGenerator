using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeScaleArmour : Thing
{
    public override string Name => "Bronze scale armour";

    public Money Price => new(16, 0, 0);

    public int MovementInhibitingFactor => -2;

    public int DamageSusceptiveValue => 2;

    public int Weight => 18;
}
