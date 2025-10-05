using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class ProtectiveCloak123Mp : MagicalObject
{
    public override string Name => "Protective Cloak (123 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 123;
}
