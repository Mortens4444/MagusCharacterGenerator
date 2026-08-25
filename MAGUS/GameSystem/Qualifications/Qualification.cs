using MAGUS.Models;

namespace MAGUS.GameSystem.Qualifications;

public abstract class Qualification : ImageOwner
{
    public virtual string Key => GetType().Name;

    public string Note = String.Empty;

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

    public virtual string Description => String.Empty;

    public QualificationLevel QualificationLevel { get; set; }

    public int BaseQualificationLevel { get; private set; }

    public int MasterQualificationLevel { get; set; }

    public int ActualLevel => QualificationLevel == QualificationLevel.Base ? BaseQualificationLevel : MasterQualificationLevel;

    public virtual int QpToBaseQualification { get; }

    public virtual int? QpToMaxBaseQualification { get; }

    public virtual int QpToMasterQualification { get; }

    /// <summary>
    /// True when this qualification instance still needs the player to pick something (a weapon type,
    /// a language) before it's fully meaningful - e.g. a WeaponUse granted automatically by class/race
    /// with no Weapon chosen yet. See WeaponQualification/LanguageLore/AncientTongueLore for the actual
    /// checks, and QualificationsView.xaml, which shows a "Choose" prompt while this is true.
    /// </summary>
    public virtual bool NeedsSelection => false;

    /// <summary>
    /// True for qualifications that offer a weapon/language pick (see NeedsSelection) even after one has
    /// already been made - QualificationsView.xaml keeps its "Choose" button visible while this is true,
    /// so the player can revisit and change an earlier pick instead of it disappearing once made.
    /// </summary>
    public virtual bool IsSelectable => false;

    public override string ToString() => Name;
}
