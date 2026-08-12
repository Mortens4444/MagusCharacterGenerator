using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class TrackingConcealment(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Tracking/concealment";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 45;

    public TrackingConcealment() : this(QualificationLevel.Base) { }
}
