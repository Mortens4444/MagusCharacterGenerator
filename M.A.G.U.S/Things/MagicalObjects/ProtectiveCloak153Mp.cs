using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class ProtectiveCloak153Mp : MagicalObject
{
    public override string Name => "Protective Cloak (153 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 153;

    public override string[] Images => ["protective_cloak.png"];
}
