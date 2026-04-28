using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class AnimalLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Animal lore";

    public override int QpToBaseQualification => 1;

    public override int QpToMasterQualification => 6;

    public AnimalLore() : this(QualificationLevel.Base) { }
}
