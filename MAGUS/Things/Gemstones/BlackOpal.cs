using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class BlackOpal : Gemstone
{
    public override string Name => "Black (Sonioni) Opal";

    public override Money Price => new(100);

    public override string Description => "immunity against spells";
}