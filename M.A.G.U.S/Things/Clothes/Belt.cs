using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Belt : Thing
{
    public override string Name => "Belt";

    public override Money Price => new(0, 0, 20);

    public override string Description => "A simple strap of leather or woven cord worn around the waist. Essential for holding one's hose or securing a scabbard and purse.";
}
