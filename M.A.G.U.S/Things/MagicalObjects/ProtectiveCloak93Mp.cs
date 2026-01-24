using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class ProtectiveCloak93Mp : MagicalObject
{
    public override string Name => "Protective Cloak (93 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 93;

    public override string[] Images => ["protective_cloak.png"];
}
