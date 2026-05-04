using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Armors;

public class MoonLunirArmor : Chainmail, INotForSale
{
    public override string Name => "Moon-Lunir Armor";

    public override Money Price => new(1500, 0, 0);

    public override int ArmorCheckPenalty => 0;

    public override int ArmorClass => 6;

    public override double Weight => 10;

    public override string Description => "Chainmail built from moon-lunir.";
}
