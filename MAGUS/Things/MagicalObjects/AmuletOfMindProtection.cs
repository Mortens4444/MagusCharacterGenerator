using MAGUS.Classes;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class AmuletOfMindProtection : MagicalObject
{
    public override string Name => "Amulet of Mind Protection";

    public override Money Price => new(0, 2);

    public override int ManaPoints => 90;

    public override IEnumerable<Class> AllowedCreators => [new Wizard()];
}
