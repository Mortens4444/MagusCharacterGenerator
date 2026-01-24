using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class HealingPotionHp : MagicalObject
{
    public override string Name => "Healing Potion (1 HP)";

    public override Money Price => new(1);

    public override int ManaPoints => 4;

    public override string[] Images => ["healing_potion.png"];
}
