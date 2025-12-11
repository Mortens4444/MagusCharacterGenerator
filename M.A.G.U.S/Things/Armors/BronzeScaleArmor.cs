using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeScaleArmor : Armor
{
    public override string Name => "Bronze scale armor";

    public override Money Price => new(16, 0, 0);

    public override int ArmorCheckPenalty => -2;

    public override int ArmorClass => 2;

    public override double Weight => 18;

    public override string Description => "Numerous small bronze scales attached to a strong backing. A good, affordable defense that sheds light blows well, though vulnerable to a direct piercing thrust between the scales.";
}
