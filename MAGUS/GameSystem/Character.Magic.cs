using MAGUS.Classes.Rogue;
using MAGUS.Classes.Sorcerer;
using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem.Magic;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Qualifications.Specialities;
using MAGUS.Utils;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

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

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private Deity deity = Deity.Unbeliever;

    public Sorcery? Sorcery { get; set; }

    /// <summary>Which god the character worships. Gates which priest spheres (and therefore which priest spells) they have access to; see DeityExtensions.GetAvailableSpheres.</summary>
    public Deity Deity
    {
        get => deity;
        set
        {
            if (value != deity)
            {
                deity = value;
                OnPropertyChanged();
                InvalidateAttackModes();
            }
        }
    }

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
                InvalidateAttackModes();
            }
        }
    }

    public DiceThrowFormula? MaxManaPointsPerLevelFormula
    {
        get
        {
            var sorcery = BaseClass?.SpecialQualifications.GetSpeciality<Sorcery>();
            if (sorcery != null)
            {
                var customAttributes = sorcery.GetType().GetMethod(nameof(sorcery.GetManaPointsModifier))?.GetCustomAttributes(false);
                return customAttributes.GetDiceThrowFormula();
            }
            return null;
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

    // Rulebook (p.121): a Statikus Pajzs keeps working even while its builder is asleep or
    // unconscious ("Védő hatását akkor is kifejti, ha a P-alkalmazó alszik, eszméletlen..."), so
    // unlike the Dynamic shield it isn't gated behind IsConscious.
    public override int GetAstralMagicResistance() => UnconsciousAstralMagicResistance + StaticAstralPsiShield + (IsConscious ? DynamicAstralPsiShield : 0);

    public override int GetMentalMagicResistance() => UnconsciousMentalMagicResistance + StaticMentalPsiShield + (IsConscious ? DynamicMentalPsiShield : 0);

    public override int GetManaPoints() => ManaPoints;

    /// <summary>
    /// Power bonus banked by <see cref="TryEmpowerSpell"/> for the spell cast currently being
    /// resolved this round (added to the spell's Power in MysticResolution, i.e. it makes
    /// the spell harder for the target to resist, not more damaging). Cleared once the round
    /// finishes; see CombatEngine.ProcessAssignmentTurnAsync.
    /// </summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int SpellPowerBonus { get; private set; }

    /// <summary>
    /// Spends extra mana to empower a specific spell: each point banks that spell's own
    /// <see cref="ISpell.PowerBonusPerManaPoint"/> as power for the round
    /// currently being resolved. The rate varies per spell.
    /// </summary>
    public bool TryEmpowerSpell(ISpell spell, int manaPoints)
    {
        if (Sorcery == null || manaPoints <= 0 || manaPoints > ManaPoints)
        {
            return false;
        }

        ManaPoints -= manaPoints;
        SpellPowerBonus += manaPoints * spell.PowerBonusPerManaPoint;
        return true;
    }

    public void ClearSpellPower() => SpellPowerBonus = 0;

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
