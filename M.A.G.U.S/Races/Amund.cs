using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Amund : Race
{
    public override sbyte Strength => 1;

    public override sbyte Stamina => 1;

    public override sbyte Beauty => 3;

    public override sbyte Astral => -1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new CantLearnPsi(),
        new ExtraMagicResistanceOnLevelUp(4),
        new MagicalResistanceRegeneration()
    ];
}
