using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Jann : Race
{
    public override sbyte Intelligence => 2;

    public override QualificationList Qualifications =>
    [
        new PsiPyarron(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ExtraPsiPointOnLevelUp(1),
        new UseWizardMentalMosaicAsPsi()
    ];
}
