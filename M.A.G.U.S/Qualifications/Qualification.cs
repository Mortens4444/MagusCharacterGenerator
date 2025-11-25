using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications;

public abstract class Qualification
{
    public Qualification(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
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

    public QualificationLevel QualificationLevel { get; set; }

    public byte BaseQualificationLevel { get; private set; }

    public byte MasterQualificationLevel { get; set; }

    public virtual byte QpToBaseQualification { get; }

    public virtual byte? QpToMaxBaseQualification { get; }

    public virtual byte QpToMasterQualification { get; }


    public Type QualificationType => GetType();
}
