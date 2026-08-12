using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class BannerOfHeroes : MagicalObject
{
    public override string Name => "Banner of Heroes";

    public override Money Price => new(10);

    public override int ManaPoints => 113;
}
