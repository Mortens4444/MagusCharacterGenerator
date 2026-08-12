using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Armors;

public class GreenLunirArmor : Chainmail, INotForSale
{
    public override string Name => "Green-Lunir Armor";

    public override Money Price => new(1200, 0, 0);

    public override int ArmorCheckPenalty => 0;

    public override int ArmorClass => 4;

    public override double Weight => 13;

    public override string Description => "Chainmail built from green-lunir.";
}
