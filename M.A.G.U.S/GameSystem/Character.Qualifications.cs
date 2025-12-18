using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    private int qualificationPoints;

    public QualificationList Qualifications { get; private set; } = [];

    public SpecialQualificationList SpecialQualifications { get; private set; } = [];

    public ObservableCollection<PercentQualification> PercentQualifications { get; private set; } = [];

    public bool CanAllocateQualificationPoints => QualificationPoints != 0;

    public int PercentQualificationPoints { get; set; }

    public int QualificationPoints
    {
        get => qualificationPoints;
        set
        {
            if (value != qualificationPoints)
            {
                qualificationPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public bool CanLearn(Qualification qualification)
    {
        return CanLearn(qualification, QualificationLevel.Base, out _) || CanLearn(qualification, QualificationLevel.Master, out _);
    }

    public bool HasQualification(Qualification qualification)
    {
        return HasQualification(qualification, QualificationLevel.Base) || HasQualification(qualification, QualificationLevel.Master);
    }

    public bool HasQualification(Qualification qualification, QualificationLevel qualificationLevel)
    {
        if (qualification is AncientTongueLore ancientTongueLore)
        {
            return Qualifications.Any(q => q is AncientTongueLore atl && atl.Language == ancientTongueLore.Language && q.QualificationLevel == qualificationLevel);
        }
        if (qualification is LanguageLore languageLore)
        {
            return Qualifications.Any(q => q is LanguageLore ll && ll.Language == languageLore.Language && q.QualificationLevel == qualificationLevel);
        }
        if (qualification is WeaponQualification weaponQualification)
        {
            return Qualifications.Any(q => q is WeaponQualification wq && wq.Weapon == weaponQualification.Weapon && q.QualificationLevel == qualificationLevel);
        }
        return Qualifications.Any(q => q.Name == qualification.Name && q.QualificationLevel == qualificationLevel);
    }

    public bool CanLearn(Qualification qualification, QualificationLevel qualificationLevel, out int requiredQualificationPoints)
    {
        var learningBase = qualificationLevel == QualificationLevel.Base;
        if (qualification is GemstoneMagic && learningBase)
        {
            requiredQualificationPoints = 0;
            return false;
        }

        var hasBase = HasQualification(qualification, QualificationLevel.Base);
        var hasMaster = HasQualification(qualification, QualificationLevel.Master);

        requiredQualificationPoints = learningBase
            ? hasMaster || hasBase ? 0 : qualification.QpToBaseQualification
            : hasMaster ? 0 : hasBase ? qualification.QpToMasterQualification - qualification.QpToBaseQualification : qualification.QpToMasterQualification;

        var alreadyLearned = learningBase ? (hasBase || hasMaster) : hasMaster;
        if (alreadyLearned)
        {
            return false;
        }

        var hasEnoughtQualificationPoints = QualificationPoints >= requiredQualificationPoints;
        return hasEnoughtQualificationPoints;
    }

    public void Learn(Qualification qualification, QualificationLevel qualificationLevel)
    {
        if (!CanLearn(qualification, qualificationLevel, out var qp))
        {
            throw new InvalidOperationException("Cannot learn this qualification");
        }
        QualificationPoints -= qp;
        Qualifications.Add(qualification);
    }

    private void Qualifications_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Qualifications));
    }

    private void CalculateQualificationPoints(ISettings? settings)
    {
        int qualificationPoints = 0;
        int percentQualificationPoints = 0;
        if (MultiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
        {
            qualificationPoints = BaseClass.BaseQualificationPoints;
            qualificationPoints += MathHelper.GetAboveAverageValue(Intelligence); // Can only be spent on scientific qualifications
            qualificationPoints += MathHelper.GetAboveAverageValue(Dexterity); // Can only be spent on non-scientific qualifications
            if (BaseClass.AddQualificationPointsOnFirstLevel || (settings?.AddQualificationPointsOnFirstLevelForAllClass ?? true))
            {
                qualificationPoints += BaseClass.QualificationPointsModifier;
            }
            for (int i = 1; i < BaseClass.Level; i++)
            {
                qualificationPoints += BaseClass.QualificationPointsModifier;
                percentQualificationPoints += BaseClass.PercentQualificationModifier;
            }
        }
        else
        {
            // TwinClass
            // When it got the new class?
            throw new NotImplementedException();
        }

        QualificationPoints = qualificationPoints;
        PercentQualificationPoints = percentQualificationPoints;
    }

    private void GetQualifications()
    {
        Qualifications.Clear();
        PercentQualifications.Clear();
        SpecialQualifications.Clear();

        foreach (var @class in Classes)
        {
            Qualifications.AddRange(@class.Qualifications.Concat(Race.Qualifications));
            PercentQualifications.AddRange(@class.PercentQualifications);

            var newQualifications = @class.FutureQualifications
                .Where(futureQualification => futureQualification.ActualLevel <= @class.Level);

            Qualifications.AddRange(newQualifications.Where(q => q.QualificationLevel == QualificationLevel.Base));
            var newMasterQualifications = newQualifications.Where(q => q.QualificationLevel == QualificationLevel.Master);
            foreach (var newMasterQualification in newMasterQualifications)
            {
                Qualifications.UpgradeOrAddQualification(newMasterQualification);
            }
        }
        var dexterityBasedPercentages = new List<Type> { typeof(Falling), typeof(Climbing), typeof(Jumping) };
        foreach (var percentQualification in PercentQualifications)
        {
            if (dexterityBasedPercentages.Contains(percentQualification.GetType()))
            {
                percentQualification.Percent += MathHelper.GetAboveAverageValue(Dexterity);
            }
        }
        if (PercentQualifications.FirstOrDefault(pq => pq is Falling) == null)
        {
            PercentQualifications.Add(new Falling(0));
        }
        if (PercentQualifications.FirstOrDefault(pq => pq is Climbing) == null)
        {
            PercentQualifications.Add(new Climbing(0));
        }
        if (PercentQualifications.FirstOrDefault(pq => pq is Jumping) == null)
        {
            PercentQualifications.Add(new Jumping(0));
        }

        SpecialQualifications.AddRange(BaseClass.SpecialQualifications);
        SpecialQualifications.AddRange(Race.SpecialQualifications);
        var cantLearnPsi = SpecialQualifications.GetSpeciality<CantLearnPsi>();
        if (cantLearnPsi != null)
        {
            for (int i = Qualifications.Count - 1; i >= 0; i--)
            {
                if (Qualifications[i] is IPsi)
                {
                    Qualifications.RemoveAt(i);
                }
            }
        }

        if (SpecialQualifications.Any(sq => sq is CanOnlyLearnPyarronPsi))
        {
            var toRemove = Qualifications
                .Where(q => q is IPsi && q is not PsiPyarron)
                .ToList();

            foreach (var q in toRemove)
            {
                Qualifications.Remove(q);
            }
        }

        OnPropertyChanged(nameof(Qualifications));
        OnPropertyChanged(nameof(PercentQualifications));
        OnPropertyChanged(nameof(SpecialQualification));
    }
}
