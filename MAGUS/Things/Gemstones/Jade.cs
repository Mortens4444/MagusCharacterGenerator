using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Jade : Gemstone
{
    public override Money Price => new(15);

    public override string Description => "music, singing, dance, sounds";
}