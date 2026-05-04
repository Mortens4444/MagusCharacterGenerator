using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Armors;

public class BlackLunirArmor : Chainmail, INotForSale
{
    public override string Name => "Black-Lunir Armor";

    public override Money Price => new(1300, 0, 0);

    public override int ArmorCheckPenalty => 0;

    public override int ArmorClass => 5;

    public override double Weight => 11;

    public override string Description => "Chainmail built from black-lunir.";
}
