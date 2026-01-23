using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class TrackingConcealment(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Tracking/concealment";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 45;

    public TrackingConcealment() : this(QualificationLevel.Base) { }
}
