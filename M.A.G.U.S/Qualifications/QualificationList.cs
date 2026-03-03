using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Qualifications;

public class QualificationList : ExtendedObservableCollection<Qualification>
{
    public void UpgradeOrAddQualification(Qualification newMasterQualification)
    {
        // WeaponUse, WeaponThrow should be handled => Or main weapons should be listed first!
        var firstBaseQualification = this.FirstOrDefault(
            qualification => qualification.ToString().Equals(newMasterQualification.ToString())
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
                var sameQualification = this.FirstOrDefault(q => q.Key == newMasterQualification.Key);
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

    public void InsertRange(int index, IEnumerable<Qualification> qualifications)
    {
        foreach (var qualification in qualifications)
        {
            Insert(index, qualification);
        }
    }

    public void AddFrom(IEnumerable<IClass> classes, IRace race)
    {
        foreach (var qualification in race.Qualifications)
        {
            UpgradeOrAddQualification(qualification);
        }

        foreach (var @class in classes)
        {
            foreach (var qualification in @class.Qualifications)
            {
                UpgradeOrAddQualification(qualification);
            }

            var newQualifications = @class.FutureQualifications
                .Where(f => f.ActualLevel <= @class.Level);

            foreach (var qualification in newQualifications)
            {
                UpgradeOrAddQualification(qualification);
            }
        }
    }

    public void RemoveBy(SpecialQualificationList specialQualifications)
    {
        var cantLearnPsi = specialQualifications.GetSpeciality<CantLearnPsi>();
        if (cantLearnPsi != null)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (this[i] is IPsi)
                {
                    RemoveAt(i);
                }
            }
        }

        if (specialQualifications.Any(sq => sq is CanOnlyLearnPyarronPsi))
        {
            var qualificationsToRemove = this.Where(q => q is IPsi && q is not PsiPyarron).ToList();
            foreach (var qualification in qualificationsToRemove)
            {
                Remove(qualification);
            }
        }
    }

    private bool Check(Qualification qualification, out Qualification? existingQualification)
    {
        if (qualification is ICanHaveMany)
        {
            existingQualification = null;
            return true;
        }

        existingQualification = this.FirstOrDefault(q => q.Key == qualification.Key);
        if (existingQualification == null)
        {
            return true;
        }

        return existingQualification.QualificationLevel < qualification.QualificationLevel;
    }
}
