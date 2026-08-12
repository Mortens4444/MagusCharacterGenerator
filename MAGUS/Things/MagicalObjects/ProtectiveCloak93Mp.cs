using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class ProtectiveCloak93Mp : MagicalObject
{
    public override string Name => "Protective Cloak (93 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 93;

    public override string[] Images => ["protective_cloak.png"];
}
