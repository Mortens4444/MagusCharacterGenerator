using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class ReadingAndWriting(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Reading and writing";

    public override byte QpToBaseQualification => 5;

    public override byte QpToMasterQualification => 25;
}
