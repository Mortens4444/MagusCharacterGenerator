using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class PotionOfDragonsBreath120Mp : MagicalObject
{
    public override string Name => "Potion of Dragon's Breath (120 MP)";

    public override Money Price => new(3);

    public override int ManaPoints => 120;

    public override IEnumerable<Class> AllowedCreators => [new Witch(), new Warlock()];

    public override string[] Images => ["potion_of_dragon_s_breath.png"];
}
