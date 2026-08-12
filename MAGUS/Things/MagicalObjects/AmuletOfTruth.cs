using MAGUS.Classes;
using MAGUS.Classes.Believer;
using MAGUS.Classes.Believer.Domvik;
using MAGUS.Classes.Believer.GodsOfKyr;
using MAGUS.Classes.Believer.GodsOfPyarron;
using MAGUS.Classes.Believer.Ranagol;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class AmuletOfTruth : MagicalObject
{
    public override string Name => "Amulet of Truth";

    public override Money Price => new(0, 2);

    public override int ManaPoints => 60;

    public override IEnumerable<Class> AllowedCreators => [new ArelPriest(), new TharrPriest(),  new KyelPriest(), new NastarPriest(), new VelarPriest(), new DomvikPriest(), new GorvikRanagolPriest(), new KrannishRanagolPriest(), new Witch()];
}
