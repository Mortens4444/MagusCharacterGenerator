using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Amund : Race
{
    public override short Strength => 1;

    public override short Stamina => 1;

    public override short Beauty => 3;

    public override short Astral => -1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new CantLearnPsi(),
        new ExtraMagicResistanceOnLevelUp(4),
        new MagicalResistanceRegeneration()
    ];
}
