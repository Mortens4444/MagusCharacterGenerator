using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class TrackingConcealment(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Tracking/concealment";

    public override byte QpToBaseQualification => 10;

    public override byte QpToMasterQualification => 45;
}
