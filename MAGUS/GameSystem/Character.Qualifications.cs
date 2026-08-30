using MAGUS.Classes.Believer.Ranagol;
using MAGUS.Classes.Fighter;
using MAGUS.Classes.Sorcerer;
using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Magic;
using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Percentages;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Qualifications.Specialities;
using MAGUS.Races;
using MAGUS.Utils;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int qualificationPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int percentQualificationPoints;

    /// <summary>Percent gained per PercentQualificationPointCost spent - see IncreasePercentQualification.</summary>
    public const int PercentPerQualificationPoint = 3;

    /// <summary>PercentQualificationPoints cost of one PercentPerQualificationPoint increase - see IncreasePercentQualification.</summary>
    public const int PercentQualificationPointCost = 1;

    public QualificationList Qualifications { get; private set; } = [];

    public SpecialQualificationList SpecialQualifications { get; private set; } = [];

    public PercentQualificationList PercentQualifications { get; private set; } = [];

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool CanAllocateQualificationPoints => QualificationPoints != 0;

    public int PercentQualificationPoints
    {
        get => percentQualificationPoints;
        set
        {
            if (value != percentQualificationPoints)
            {
                percentQualificationPoints = value;
                OnPropertyChanged();
            }
        }
    }

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

    public TSpecialQualification? GetSpeciality<TSpecialQualification>()
        where TSpecialQualification : SpecialQualification
    {
        return Race.SpecialQualifications.GetSpeciality<TSpecialQualification>() ?? BaseClass.SpecialQualifications.GetSpeciality<TSpecialQualification>();
    }

    // Move these to QualificationList and fixy Hilvar
    public bool HasQualification(Qualification qualification)
    {
        return HasQualification(qualification, QualificationLevel.Base) || HasQualification(qualification, QualificationLevel.Master);
    }

    public bool HasPsi()
    {
        return Qualifications.Any(q => q is IPsi);
    }

    public bool HasRunicMagic()
    {
        return Qualifications.Any(q => q is RunicMagic);
    }

    /// <summary>
    /// True if this character can meaningfully treat an injury - the Healing qualification
    /// (MAGUS.Qualifications.Scientific.Healing), Poisoning/neutralization (just as valid for a
    /// venom/poison-flavored injury - see VenomInTheBloodAlidax), or a known spell marked
    /// IHealingSpell (see KissOfLife/Suturing). Used to gate the Heal quest mechanic
    /// (CharacterViewModel.HealAsync).
    /// </summary>
    public bool CanHeal()
    {
        return Qualifications.Any(q => q is Healing or PoisoningAndNeutralization) || SpellCatalog.GetAvailable(this).Any(s => s is IHealingSpell);
    }

    /// <summary>
    /// Best available chance (0-100) of spotting a trap or secret door - the higher of
    /// TrapDetection/SecretDoorSearch's own Percent, or 0 if the character has neither. Used as the
    /// success chance for the trap/secret-door quest mechanic (CharacterViewModel.SearchForTrapsAsync)
    /// instead of a flat difficulty, since these percent qualifications already represent exactly
    /// this kind of skill-based chance.
    /// </summary>
    public int TrapSearchSkillPercent()
    {
        var trapDetection = PercentQualifications.OfType<TrapDetection>().Select(q => q.Percent).DefaultIfEmpty(0).Max();
        var secretDoorSearch = PercentQualifications.OfType<SecretDoorSearch>().Select(q => q.Percent).DefaultIfEmpty(0).Max();
        return Math.Max(trapDetection, secretDoorSearch);
    }

    /// <summary>True if this character has enough PercentQualificationPoints to raise percentQualification's Percent by one increment - see IncreasePercentQualification.</summary>
    public bool CanIncreasePercentQualification(PercentQualification percentQualification)
    {
        return percentQualification != null && PercentQualifications.Contains(percentQualification) && PercentQualificationPoints >= PercentQualificationPointCost;
    }

    /// <summary>
    /// Spends PercentQualificationPointCost PercentQualificationPoints to raise a percent qualification's
    /// Percent by PercentPerQualificationPoint - only some classes (Első Törvénykönyv), e.g. Thief/Bard/
    /// Warlock, earn PercentQualificationPoints per level (see Class.PercentQualificationModifier) to
    /// spend this way.
    /// </summary>
    public void IncreasePercentQualification(PercentQualification percentQualification)
    {
        if (!CanIncreasePercentQualification(percentQualification))
        {
            throw new InvalidOperationException("Not enough percent qualification points");
        }

        PercentQualificationPoints -= PercentQualificationPointCost;
        percentQualification.Percent += PercentPerQualificationPoint;
    }

    public bool HasQualification(Qualification qualification, QualificationLevel qualificationLevel)
    {
        return FindQualification(qualification, qualificationLevel) != null;
    }

    /// <summary>
    /// Returns the already owned qualification that represents the same skill as <paramref name="qualification"/>,
    /// optionally restricted to a given level. Returns null when the character does not have it.
    /// </summary>
    private Qualification? FindQualification(Qualification qualification, QualificationLevel? qualificationLevel = null)
    {
        return Qualifications.FirstOrDefault(q => IsSameQualification(q, qualification)
            && (qualificationLevel == null || q.QualificationLevel == qualificationLevel));
    }

    /// <summary>
    /// Two qualifications describe the same skill when they are of the same concrete type and their
    /// discriminator (language, ancient language or weapon type) matches as well.
    /// </summary>
    private static bool IsSameQualification(Qualification owned, Qualification other)
    {
        if (owned.GetType() != other.GetType())
        {
            return false;
        }

        return (owned, other) switch
        {
            (AncientTongueLore ownedAtl, AncientTongueLore otherAtl) => ownedAtl.Language == otherAtl.Language,
            (LanguageLore ownedLl, LanguageLore otherLl) => ownedLl.Language == otherLl.Language,
            // Weapons are compared by their type, not by their per-instance Id, because every Weapon
            // instance gets a fresh Guid. This is consistent with WeaponQualification.Key.
            (WeaponQualification ownedWq, WeaponQualification otherWq) => ownedWq.Weapon?.GetType() == otherWq.Weapon?.GetType(),
            _ => owned.Name == other.Name
        };
    }

    public bool CanLearn(Qualification qualification, QualificationLevel qualificationLevel)
    {
        return CanLearn(qualification, qualificationLevel, out _);
    }

    public bool CanLearn(Qualification qualification, QualificationLevel qualificationLevel, out int requiredQualificationPoints)
    {
        var krannishClasses = new List<Type>() { typeof(KrannishWarlock), typeof(KrannishRanagolPriest) };
        if (qualification is PsiKrannish && !krannishClasses.Contains(BaseClass.GetType()))
        {
            requiredQualificationPoints = 0;
            return false;
        }

        if (qualification is INotForLearn)
        {
            requiredQualificationPoints = 0;
            return false;
        }

        var learningBase = qualificationLevel == QualificationLevel.Base;
        if (qualification is GemstoneMagic && learningBase)
        {
            requiredQualificationPoints = 0;
            return false;
        }

        var cantLearnPsi = Race.SpecialQualifications.GetSpeciality<CantLearnPsi>();
        if (cantLearnPsi != null && qualification is IPsi)
        {
            requiredQualificationPoints = 0;
            return false;
        }

        if (qualification is ICanHaveMany)
        {
            requiredQualificationPoints = qualification.QpToBaseQualification;
            return IsHardLearner(qualification, ref requiredQualificationPoints, qualificationLevel);
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

        return IsHardLearner(qualification, ref requiredQualificationPoints, qualificationLevel);
    }

    private bool IsHardLearner(Qualification qualification, ref int requiredQualificationPoints, QualificationLevel qualificationLevel)
    {
        if (qualification is IScientificQualification)
        {
            requiredQualificationPoints = BaseClass switch
            {
                Amazon => requiredQualificationPoints * 3,
                Barbarian => ((qualification is LanguageLore || qualification is ReadingAndWriting || qualification is AncientTongueLore || qualification is LegendLore || qualification is HistoryLore || qualification is ReligionLore) && qualificationLevel == QualificationLevel.Base) || qualification is Healing || qualification is PoisoningAndNeutralization || qualification is Herbalism ? requiredQualificationPoints : 10000,
                _ => requiredQualificationPoints
            };
        }
        if (qualification is ILaicalQualification)
        {
            requiredQualificationPoints = BaseClass switch
            {
                Barbarian => (int)Math.Round(requiredQualificationPoints * 1.5),
                _ => requiredQualificationPoints
            };
        }
        return QualificationPoints >= requiredQualificationPoints;
    }

    public void Learn(Qualification qualification, QualificationLevel qualificationLevel)
    {
        if (BaseClass is Duelist && (qualification is not LanguageLore))
        {
            throw new InvalidOperationException("Cannot learn new qualifications, except languages");
        }

        if (!CanLearn(qualification, qualificationLevel, out var qp))
        {
            throw new InvalidOperationException("Cannot learn this qualification");
        }
        QualificationPoints -= qp;

        var existingQualification = qualification is ICanHaveMany ? null : FindQualification(qualification);
        if (existingQualification != null)
        {
            // Already owned at base level: upgrade it in place instead of adding a second entry,
            // otherwise the character would show both the base and the master level of the same skill.
            existingQualification.QualificationLevel = qualificationLevel;
            if (qualificationLevel == QualificationLevel.Master && existingQualification.MasterQualificationLevel < 1)
            {
                existingQualification.MasterQualificationLevel = 1;
            }
            OnPropertyChanged(nameof(Qualifications));
            if (existingQualification is IPsi)
            {
                CalculatePsiPoints(Race is Jann, settings);
            }
            return;
        }

        qualification.QualificationLevel = qualificationLevel;
        if (qualificationLevel == QualificationLevel.Master && qualification.MasterQualificationLevel < 1)
        {
            qualification.MasterQualificationLevel = 1;
        }
        Qualifications.Add(qualification);

        // PsiPoints/MaxPsiPoints are cached (see CalculatePsiPoints) and otherwise only refresh when
        // Intelligence changes - learning a brand-new Psi qualification here would otherwise leave the
        // character showing 0 psi points until some unrelated action happened to touch Intelligence.
        if (qualification is IPsi)
        {
            CalculatePsiPoints(Race is Jann, settings);
        }
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
                qualificationPoints += BaseClass.GetQualificationPointsModifierForLevel(i + 1);
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
        var qualifications = new QualificationList();
        var percentQualifications = new PercentQualificationList();
        var specialQualifications = new SpecialQualificationList();
        
        qualifications.AddFrom(Classes, Race);
        percentQualifications.AddFrom(Classes, Dexterity);
        specialQualifications.AddFrom(Classes, Race);

        qualifications.RemoveBy(specialQualifications);

        Qualifications = qualifications;
        PercentQualifications = percentQualifications;
        SpecialQualifications = specialQualifications;

        OnPropertyChanged(nameof(Qualifications));
        OnPropertyChanged(nameof(PercentQualifications));
        OnPropertyChanged(nameof(SpecialQualifications));
    }
}
