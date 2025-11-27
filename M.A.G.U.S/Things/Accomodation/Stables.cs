using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Accomodation;

public class Stables : Thing
{
    public override Money Price => new(0, 0, 2);

    public override string Description => "Equine Housing\r\n\r\nThe Beast's Rest. A well-maintained section where horses, mules, and donkeys may be stabled and cared for. Hay, fresh water, and a groom's service are provided for a modest fee. Essential for those who ride the roads and value the safety of their faithful mounts.";
}
