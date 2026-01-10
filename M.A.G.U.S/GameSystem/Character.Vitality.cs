using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxHealthPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxPainTolerancePoints;

    public override int ActualHealthPoints { get; set; }

    public override int ActualPainTolerancePoints { get; set; }

    public int MaxHealthPoints
    {
        get => maxHealthPoints;
        set
        {
            if (value != maxHealthPoints)
            {
                maxHealthPoints = value;
                ActualHealthPoints = value;
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
                ActualPainTolerancePoints = value;
                OnPropertyChanged();
            }
        }
    }

    private void CalculateLifePoints()
    {
        ActualHealthPoints = BaseClass.BaseLifePoints;
        var additionalLifePoints = Race.SpecialQualifications.GetSpeciality<AdditionalLifePoints>();
        if (additionalLifePoints != null)
        {
            ActualHealthPoints += additionalLifePoints.ExtraLifePoints;
        }
        ActualHealthPoints += MathHelper.GetAboveAverageValue(Health);
        MaxHealthPoints = ActualHealthPoints;
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

            var startLevel = BaseClass.AddPainToleranceOnFirstLevel || (settings?.AddPainToleranceOnFirstLevelForAllClass ?? true) ? 1 : 2;
            if (settings?.AutoIncreasePainTolerance ?? true)
            {
                for (var level = startLevel; level <= BaseClass.Level; level++)
                {
                    painTolerancePoints += BaseClass.GetPainToleranceModifier();
                }
            }
        }
        else
        {
            throw new NotImplementedException();
        }

        MaxPainTolerancePoints = painTolerancePoints;
    }
}
