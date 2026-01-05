using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int manaPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxManaPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int unconsciousAstralMagicResistance;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int unconsciousMentalMagicResistance;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int staticAstralPsiShield;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int staticMentalPsiShield;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int dynamicAstralPsiShield;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int dynamicMentalPsiShield;

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

    public int StaticAstralPsiShield
    {
        get => staticAstralPsiShield;
        set
        {
            if (value != staticAstralPsiShield)
            {
                staticAstralPsiShield = value;
                OnPropertyChanged();
            }
        }
    }

    public int StaticMentalPsiShield
    {
        get => staticMentalPsiShield;
        set
        {
            if (value != staticMentalPsiShield)
            {
                staticMentalPsiShield = value;
                OnPropertyChanged();
            }
        }
    }

    public int DynamicAstralPsiShield
    {
        get => dynamicAstralPsiShield;
        set
        {
            if (value != dynamicAstralPsiShield)
            {
                dynamicAstralPsiShield = value;
                OnPropertyChanged();
            }
        }
    }

    public int DynamicMentalPsiShield
    {
        get => dynamicMentalPsiShield;
        set
        {
            if (value != dynamicMentalPsiShield)
            {
                dynamicMentalPsiShield = value;
                OnPropertyChanged();
            }
        }
    }

    private void CalculateUnconsciousAstralMagicResistance()
    {
        var extraMagicResistanceOnLevelUp = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousAstralMagicResistance = BaseClass is Shaman ? Astral + Level * 4 :  MathHelper.GetAboveAverageValue(Astral);
        UnconsciousAstralMagicResistance += (BaseClass.Level - 1) * (extraMagicResistanceOnLevelUp?.ExtraResistancePoints ?? 0);
    }

    private void CalculateUnconsciousMentalMagicResistance()
    {
        var extraMagicResistanceOnLevelUp = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousMentalMagicResistance = BaseClass is Shaman ? Willpower + Level * 4 : MathHelper.GetAboveAverageValue(Willpower);
        UnconsciousMentalMagicResistance += (BaseClass.Level - 1) * (extraMagicResistanceOnLevelUp?.ExtraResistancePoints ?? 0);
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
