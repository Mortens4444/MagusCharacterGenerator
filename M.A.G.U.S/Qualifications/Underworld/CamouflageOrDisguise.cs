using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Underworld;

public class CamouflageOrDisguise : Qualification
{
    public CamouflageOrDisguise(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
        : base(qualificationLevel, level)
    {
    }

    public override string Name => "Camouflage/disguise";

    public override int QpToBaseQualification => 12;

    public override int QpToMasterQualification => 24;
}
