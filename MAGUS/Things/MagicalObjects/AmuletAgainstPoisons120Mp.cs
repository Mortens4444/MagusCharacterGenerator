using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class AmuletAgainstPoisons120Mp : MagicalObject
{
    public override string Name => "Amulet Against Poisons (120 MP)";

    public override string[] Images => ["amulet_against_poisons.png"];

    public override Money Price => new(0, 2);

    public override int ManaPoints => 120;

    public override IEnumerable<Class> AllowedCreators => [ new Witch(), new Warlock() ];
}
