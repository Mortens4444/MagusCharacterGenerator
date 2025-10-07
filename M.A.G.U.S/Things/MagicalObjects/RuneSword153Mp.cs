using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class RuneSword153Mp : MagicalObject
{
    public Thing TargetItem { get; set; }

    public override string Name => "Rune Sword (153 MP)";

    public override Money Price => Money.DoubleIt(TargetItem?.Price ?? new(0));

    public override int ManaPoints => 153;
}
