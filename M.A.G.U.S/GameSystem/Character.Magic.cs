using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    private int manaPoints;
    private int maxManaPoints;
    private int unconsciousAstralMagicResistance;
    private int unconsciousMentalMagicResistance;

    public Sorcery? Sorcery { get; set; }

    public int MaxManaPointsPerLevel { get; set; }

    public int ManaPoints
    {
        get => manaPoints;
        set
        {
            if (value != manaPoints)
            {
                manaPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxManaPoints
    {
        get => maxManaPoints;
        set
        {
            if (value != maxManaPoints)
            {
                maxManaPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int UnconsciousAstralMagicResistance
    {
        get => unconsciousAstralMagicResistance;
        set
        {
            if (value != unconsciousAstralMagicResistance)
            {
                unconsciousAstralMagicResistance = value;
                OnPropertyChanged();
            }
        }
    }

    public int UnconsciousMentalMagicResistance
    {
        get => unconsciousMentalMagicResistance;
        set
        {
            if (value != unconsciousMentalMagicResistance)
            {
                unconsciousMentalMagicResistance = value;
                OnPropertyChanged();
            }
        }
    }

    private void CalculateUnconsciousAstralMagicResistance()
    {
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousAstralMagicResistance = MathHelper.GetAboveAverageValue(Astral);
        UnconsciousAstralMagicResistance += (BaseClass.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0);
    }

    private void CalculateUnconsciousMentalMagicResistance()
    {
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousMentalMagicResistance = MathHelper.GetAboveAverageValue(Willpower);
        UnconsciousMentalMagicResistance += (BaseClass.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0);
    }

    private void CalculateManaPoints(ISettings? settings)
    {
        var extraManaPointsOnLevelUp = Race.SpecialQualifications.GetSpeciality<ExtraManaPointOnLevelUp>();
        var extraManaPoints = extraManaPointsOnLevelUp == null ? 0 : extraManaPointsOnLevelUp.ExtraManaPoints * BaseClass.Level;

        var kyrLore = Race.SpecialQualifications.GetSpeciality<KyrLore>();

        var sorceryAttributes = new SorceryAttributes
        {
            ManaPoints = 0,
            MaxManaPointsPerLevel = 0,
            Sorcery = null
        };
        foreach (var @class in Classes)
        {
            if (@class.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is Sorcery) is Sorcery sorcery)
            {
                if (BaseClass is Bard)
                {
                    sorcery.ManaPoints = MathHelper.GetAboveAverageValue(Intelligence);
                }
                var manaPoints = sorcery.ManaPoints;
                if (kyrLore != null)
                {
                    manaPoints += BaseClass.Level;
                }
                for (int lvl = 1; lvl <= @class.Level; lvl++)
                {
                    if (lvl > 1 || (settings?.AddManaPointsOnFirstLevelForAllClass ?? false))
                    {
                        manaPoints += sorcery.GetManaPointsModifier();
                    }
                }
                //maxManaPointsPerLevel = sorcery.GetManaPointsModifier();

                if (sorceryAttributes.ManaPoints < manaPoints)
                {
                    sorceryAttributes = new SorceryAttributes
                    {
                        ManaPoints = manaPoints + extraManaPoints,
                        MaxManaPointsPerLevel = sorcery.GetManaPointsModifier(),
                        Sorcery = sorcery
                    };
                }
            }
        }

        Sorcery = sorceryAttributes.Sorcery;
        ManaPoints = sorceryAttributes.ManaPoints;
        MaxManaPoints = sorceryAttributes.ManaPoints;
        MaxManaPointsPerLevel = sorceryAttributes.MaxManaPointsPerLevel;
    }
}
