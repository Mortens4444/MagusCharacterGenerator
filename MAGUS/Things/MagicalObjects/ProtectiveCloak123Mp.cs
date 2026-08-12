using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.MagicalObjects;

public class ProtectiveCloak123Mp : MagicalObject
{
    public override string Name => "Protective Cloak (123 MP)";

    public override Money Price => new(4);

    public override int ManaPoints => 123;

    public override string[] Images => ["protective_cloak.png"];
}
