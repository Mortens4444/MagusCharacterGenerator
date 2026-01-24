using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Believer;
using M.A.G.U.S.Classes.Believer.Domvik;
using M.A.G.U.S.Classes.Believer.GodsOfKyr;
using M.A.G.U.S.Classes.Believer.GodsOfPyarron;
using M.A.G.U.S.Classes.Believer.Ranagol;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class AmuletOfTruth : MagicalObject
{
    public override string Name => "Amulet of Truth";

    public override Money Price => new(0, 2);

    public override int ManaPoints => 60;

    public override IEnumerable<Class> AllowedCreators => [new ArelPriest(), new TharrPriest(),  new KyelPriest(), new NastarPriest(), new VelarPriest(), new DomvikPriest(), new GorvikRanagolPriest(), new KrannishRanagolPriest(), new Witch()];
}
