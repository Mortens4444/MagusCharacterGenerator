using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Qualifications.Specialities;
using MAGUS.Utils;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxHealthPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int? maxPainTolerancePoints;

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

    public int? MaxPainTolerancePoints
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

    public int DeathCount { get; set; }

    /// <summary>
    /// Brings this character back to full health - restoring ActualHealthPoints/ActualPainTolerancePoints
    /// to their maximums heals every wound in the same stroke, and clears the one-shot
    /// diedRaised/lostConsciousnessRaised latches (see Attacker) so a character who dies again later
    /// still raises Died/LostConsciousness instead of staying silently inert. Safe to call on a
    /// character who was never dead - it's just a full heal at that point. Does not restore
    /// ManaPoints/PsiPoints, which aren't wounds. See MAGUS.Things.MagicalObjects.WaterOfLife and
    /// CharacterCareActions.UseHealingItemAsync.
    /// </summary>
    public void Revive()
    {
        diedRaised = false;
        lostConsciousnessRaised = false;

        ActualHealthPoints = MaxHealthPoints;
        ActualPainTolerancePoints = MaxPainTolerancePoints;
    }

    private void OnDied(object? sender, EventArgs e)
    {
        DeathCount++;
        OnPropertyChanged(nameof(DeathCount));
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
                    painTolerancePoints += BaseClass.GetPainToleranceModifier(level);
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
