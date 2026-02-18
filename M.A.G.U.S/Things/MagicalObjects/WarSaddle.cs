using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class WarSaddle : MagicalObject
{
    public override string Name => "War Saddle (Magical)";

    public override string[] Images => ["war_saddle_magical.png"];

    public override Money Price => new(6);

    public override int ManaPoints => 43;
}
