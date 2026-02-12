using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class PotionOfDragonsBreath90Mp : MagicalObject
{
    public override string Name => "Potion of Dragon's Breath (90 MP)";

    public override Money Price => new(3);

    public override int ManaPoints => 90;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];

    public override string[] Images => ["potion_of_dragon_s_breath.png"];
}
