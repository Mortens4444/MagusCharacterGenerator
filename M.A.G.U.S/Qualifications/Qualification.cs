using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions.Services;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.Qualifications;

public abstract class Qualification : IHaveImage
{
    public Qualification(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    {
        QualificationLevel = qualificationLevel;
        if (qualificationLevel == QualificationLevel.Base)
        {
            BaseQualificationLevel = level;
            MasterQualificationLevel = 0;
        }
        else
        {
            BaseQualificationLevel = 0;
            MasterQualificationLevel = level;
        }
    }

    public virtual string Category => GetType().Namespace?[(GetType().Namespace.LastIndexOf('.') + 1)..] ?? String.Empty;

    public virtual string Name => GetType().Name;

    public virtual string Description => String.Empty;

    public virtual string[] Images => [$"{Name.ToImageName()}.png"];

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string DefaultImage => Images.Length > 0 ? Images[0] : String.Empty;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string RandomImage => Images.Length > 1 ? Images[RandomProvider.GetSecureRandomInt(0, Images.Length)] : DefaultImage;

    public QualificationLevel QualificationLevel { get; set; }

    public int BaseQualificationLevel { get; private set; }

    public int MasterQualificationLevel { get; set; }

    public int ActualLevel => QualificationLevel == QualificationLevel.Base ? BaseQualificationLevel : MasterQualificationLevel;

    public virtual int QpToBaseQualification { get; }

    public virtual int? QpToMaxBaseQualification { get; }

    public virtual int QpToMasterQualification { get; }

    public override string ToString()
    {
        return Name;
    }
}
