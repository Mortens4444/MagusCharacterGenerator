using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class NaturalArmor : SpecialQualification
{
    public int ArmorClass { get; init; }

    public override string Name => "Natural armor";

    public NaturalArmor(int armorClass)
    {
        ArmorClass = armorClass;
    }

    public override string ToString()
    {
        return $" ({ArmorClass})";
    }
}
