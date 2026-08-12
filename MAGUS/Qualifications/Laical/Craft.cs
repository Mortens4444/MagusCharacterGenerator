using MAGUS.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace MAGUS.Qualifications.Laical;

public class Craft : Qualification, ILaicalQualification
{
    public Profession Profession { get; set; }

    [System.Text.Json.Serialization.JsonConstructor, JsonConstructor]
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
