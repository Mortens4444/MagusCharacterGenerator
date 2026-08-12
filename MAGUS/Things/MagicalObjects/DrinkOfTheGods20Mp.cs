using MAGUS.Classes;
using MAGUS.Classes.Believer.Domvik;
using MAGUS.Classes.Believer.GodsOfKyr;
using MAGUS.Classes.Believer.GodsOfPyarron;
using MAGUS.Classes.Believer.Ranagol;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class DrinkOfTheGods20Mp : MagicalObject
{
    public override string Name => "Drink of the Gods (20 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 20;

    public override IEnumerable<Class> AllowedCreators => [new ArelPriest(), new TharrPriest(), new KyelPriest(), new NastarPriest(), new VelarPriest(), new DomvikPriest(), new GorvikRanagolPriest(), new KrannishRanagolPriest(), new Witch()];

    public override string[] Images => ["drink_of_the_gods.png"];
}
