using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Gemstones;

public class Onyx : Gemstone
{
    public override Money Price => new(5);

    public override string Description => "discord, enmity";
}