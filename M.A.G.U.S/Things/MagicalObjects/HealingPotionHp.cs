using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.MagicalObjects;

public class HealingPotionHp : MagicalObject
{
    public override string Name => "Healing Potion (1 HP)";

    public override Money Price => new(1);
}
