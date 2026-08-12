using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class ProtectiveCloak63Mp : MagicalObject
{
    public override string Name => "Protective Cloak (63 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 63;

    public override string[] Images => ["protective_cloak.png"];
}
