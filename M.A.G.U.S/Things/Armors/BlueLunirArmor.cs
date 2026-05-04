using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Armors;

public class BlueLunirArmor : Chainmail, INotForSale
{
    public override string Name => "Blue-Lunir Armor";

    public override Money Price => new(900, 0, 0);

    public override int ArmorCheckPenalty => 1;

    public override int ArmorClass => 4;

    public override double Weight => 14;

    public override string Description => "Chainmail built from blue-lunir.";
}
