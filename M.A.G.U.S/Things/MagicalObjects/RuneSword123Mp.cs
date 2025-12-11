using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class RuneSword123Mp : RuneSword
{
    public Thing TargetItem { get; set; }

    public override string Name => "Rune Sword (123 MP)";

    public override Money Price => Money.DoubleIt(TargetItem?.Price ?? new(0));

    public override int ManaPoints => 123;
}
