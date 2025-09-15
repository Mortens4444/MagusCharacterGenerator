using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications;

public class Qualification
{
    public Qualification(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
    {
        QualificationLevel = qualificationLevel;
        if (qualificationLevel == QualificationLevel.Base)
        {
            BaseQualificationLevel = level;
        }
        else
        {
            BaseQualificationLevel = level;
            MasterQualificationLevel = level;
        }
    }

    public virtual string Name => GetType().Name;
    
    public QualificationLevel QualificationLevel { get; set; }

    public byte BaseQualificationLevel { get; private set; }

    public byte MasterQualificationLevel { get; set; }

    public Type QualificationType => GetType();
}
