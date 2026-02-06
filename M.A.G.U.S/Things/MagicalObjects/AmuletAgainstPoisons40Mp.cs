using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletAgainstPoisons40Mp : MagicalObject
{
    public override string Name => "Amulet Against Poisons (40 MP)";

    public override string[] Images => ["amulet_against_poisons.png"];

    public override Money Price => new(0, 2);

    public override int ManaPoints => 40;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];
}
