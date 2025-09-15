using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications;

public class QualificationList : List<Qualification>
{
    public void UpgradeOrAddQualification(Qualification newMasterQualification)
    {
        // WeaponUsage, WeaponThrow should be handled => Or main weapons should be listed first!
        var firstBaseQualification = this.FirstOrDefault(
            qualification => qualification.GetType().Equals(newMasterQualification.GetType())
            && qualification.QualificationLevel == QualificationLevel.Base);
        if (firstBaseQualification != null)
        {
            firstBaseQualification.QualificationLevel = QualificationLevel.Master;
            firstBaseQualification.MasterQualificationLevel = newMasterQualification.MasterQualificationLevel;
        }
        else
        {
            if (newMasterQualification is ICanHaveMany)
            {
                Add(newMasterQualification);
            }
            else
            {
                var sameQualification = this.FirstOrDefault(q => q.GetType() == newMasterQualification.GetType());
                if (sameQualification != null)
                {
                    if (sameQualification.QualificationLevel == QualificationLevel.Base && newMasterQualification.QualificationLevel == QualificationLevel.Master)
                    {
                        sameQualification.QualificationLevel = QualificationLevel.Master;
                    }
                }
                else
                {
                    Add(newMasterQualification);
                }
            }
        }
    }

    public new void Insert(int index, Qualification qualification)
    {
        if (Check(qualification, out var existingQualification))
        {
            base.Insert(index, qualification);
            if (existingQualification != null)
            {
                Remove(existingQualification);
            }
        }
    }

    public new void Add(Qualification qualification)
    {
        if (Check(qualification, out var existingQualification))
        {
            base.Add(qualification);
            if (existingQualification != null)
            {
                Remove(existingQualification);
            }
        }
    }

    public new void InsertRange(int index, IEnumerable<Qualification> qualifications)
    {
        foreach (var qualification in qualifications)
        {
            Insert(index, qualification);
        }
    }

    public new void AddRange(IEnumerable<Qualification> qualifications)
    {
        foreach (var qualification in qualifications)
        {
            Add(qualification);
        }
    }

    private bool Check(Qualification qualification, out Qualification existingQualification)
    {
        if (qualification is ICanHaveMany)
        {
            existingQualification = null;
            return true;
        }

        existingQualification = this.FirstOrDefault(q => q.QualificationType == qualification.QualificationType);
        if (existingQualification == null)
        {
            return true;
        }

        if (existingQualification.QualificationLevel < qualification.QualificationLevel)
        {
            return true;
        }
        return false;
    }
}
