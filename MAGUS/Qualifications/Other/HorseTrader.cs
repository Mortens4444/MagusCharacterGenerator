using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Other;

public class HorseTrader(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public HorseTrader() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;

    public override string Name => "Horse Trader";
}
