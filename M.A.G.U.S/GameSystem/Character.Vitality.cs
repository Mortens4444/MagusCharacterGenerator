using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int healthPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxHealthPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int painTolerancePoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxPainTolerancePoints;

    public int HealthPoints
    {
        get => healthPoints;
        set
        {
            if (value != healthPoints)
            {
                healthPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxHealthPoints
    {
        get => maxHealthPoints;
        set
        {
            if (value != maxHealthPoints)
            {
                maxHealthPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int PainTolerancePoints
    {
        get => painTolerancePoints;
        set
        {
            if (value != painTolerancePoints)
            {
                painTolerancePoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxPainTolerancePoints
    {
        get => maxPainTolerancePoints;
        set
        {
            if (value != maxPainTolerancePoints)
            {
                maxPainTolerancePoints = value;
                OnPropertyChanged();
            }
        }
    }

    private void CalculateLifePoints()
    {
        var additionalLifePoints = Race.SpecialQualifications.GetSpeciality<AdditionalLifePoints>();
        HealthPoints = BaseClass.BaseLifePoints;
        if (additionalLifePoints != null)
        {
            HealthPoints = additionalLifePoints.ExtraLifePoints;
        }
        HealthPoints += MathHelper.GetAboveAverageValue(Health);
        MaxHealthPoints = HealthPoints;
    }

    private void CalculatePainTolerancePoints(ISettings? settings)
    {
        int painTolerancePoints = 0;
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<DoubledPainToleranceBase>();
        if (MultiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
        {
            painTolerancePoints = doubledPainToleranceBase != null ? 2 * BaseClass.BasePainTolerancePoints : BaseClass.BasePainTolerancePoints;
            painTolerancePoints += MathHelper.GetAboveAverageValue(Stamina);
            painTolerancePoints += MathHelper.GetAboveAverageValue(Willpower);
            if (BaseClass.AddPainToleranceOnFirstLevel || (settings?.AddPainToleranceOnFirstLevelForAllClass ?? true))
            {
                painTolerancePoints += BaseClass.GetPainToleranceModifier();
            }

            for (int i = 1; i < BaseClass.Level; i++)
            {
                painTolerancePoints += BaseClass.GetPainToleranceModifier();
            }
        }
        else
        {
            throw new NotImplementedException();
        }

        PainTolerancePoints = painTolerancePoints;
        MaxPainTolerancePoints = PainTolerancePoints;
        OnPropertyChanged(nameof(PainTolerancePoints));
    }
}
