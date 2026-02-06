using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class HealingPotionPrp : MagicalObject
{
    public override string Name => "Healing Potion (1 PRP)";

    public override Money Price => new(0, 5);

    public override int ManaPoints => 2;

    public override string[] Images => ["healing_potion_prp.png"];
}
