using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Armors;

public class RedLunirArmor : Chainmail, INotForSale
{
    public override string Name => "Red-Lunir Armor";

    public override Money Price => new(1000, 0, 0);

    public override int ArmorCheckPenalty => 0;

    public override int ArmorClass => 3;

    public override double Weight => 13;

    public override string Description => "Chainmail built from red-lunir.";
}
