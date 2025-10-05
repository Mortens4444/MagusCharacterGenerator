using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class RuneArmor123Mp : MagicalObject
{
    public override string Name => "Rune Armor (123 MP)";

    public override Money Price => Money.Double;

    public override int ManaPoints => 123;
}
