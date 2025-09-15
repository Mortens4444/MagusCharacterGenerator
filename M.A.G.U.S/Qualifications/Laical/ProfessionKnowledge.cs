using M.A.G.U.S.GameSystem.Qualifications;
using Newtonsoft.Json;

namespace M.A.G.U.S.Qualifications.Laical;

public class ProfessionKnowledge : Qualification
{
    public Profession Profession { get; set; }

    [JsonConstructor]
    public ProfessionKnowledge() { }

    public ProfessionKnowledge(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
    {
    }

    public ProfessionKnowledge(Profession profession, QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
        Profession = profession;
    }
}
