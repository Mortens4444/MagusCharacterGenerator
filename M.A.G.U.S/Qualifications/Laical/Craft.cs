using M.A.G.U.S.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace M.A.G.U.S.Qualifications.Laical;

public class Craft : Qualification
{
    public Profession Profession { get; set; }

    [JsonConstructor]
    public Craft() { }

    public Craft(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
            : base(qualificationLevel, level)
    {
    }

    public Craft(Profession profession, QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
        : base(qualificationLevel, level)
    {
        Profession = profession;
    }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;
}
