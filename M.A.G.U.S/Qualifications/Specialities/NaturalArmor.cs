using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class NaturalArmor : SpecialQualification
{
    public int ArmorClass { get; init; }

    public override string Name => "Natural armor";

    public NaturalArmor(int armorClass)
    {
        ArmorClass = armorClass;
    }
}
