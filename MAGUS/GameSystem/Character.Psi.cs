using MAGUS.GameSystem.CombatModifiers;
using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications.Specialities;
using MAGUS.Utils;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int psiPoints;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int maxPsiPoints;

    public const int KyrModifier = 6;
    public const int SlanModifier = 5;
    public const int PyarronMasterModifier = 4;
    public const int PyarronBaseModifier = 3;

    public IPsi? Psi { get; set; }

    public int PsiPointsModifier { get; set; }

    public int PsiPoints
    {
        get => psiPoints;
        set
        {
            if (value != psiPoints)
            {
                psiPoints = value;
                OnPropertyChanged();
                InvalidateAttackModes();
            }
        }
    }

    public int MaxPsiPoints
    {
        get => maxPsiPoints;
        set
        {
            if (value != maxPsiPoints)
            {
                maxPsiPoints = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Attack value bonus banked by <see cref="TryUsePsiSurge"/> for the round currently being
    /// resolved. Cleared once that round finishes (see CombatEngine.ProcessAssignmentTurnAsync),
    /// so it applies to every attack the character makes this round without being wiped by the
    /// per-initiative TemporaryModifiers reset used for direction modifiers.
    /// </summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int PsiSurgeAttackBonus { get; private set; }

    public const int PsiSurgeAttackValuePerPoint = 2;

    /// <summary>
    /// Roham - General Diszciplína (p.118-119), offensive half of Roham (Megfékezés). The book
    /// makes this an all-or-nothing spend: it burns every Psi point the character currently has
    /// available, including any parked in a Dinamikus Pajzs ("A diszciplína felemészti az
    /// alkalmazó összes aktuális Pp-ját, beleértve a Dinamikus Pajzsban tároltakat is") - there is
    /// no partial-amount option. Each point banks +2 attack value for the round currently being
    /// resolved. Available to any character with psi, regardless of discipline/school. See
    /// <see cref="TryUseMegfekezes"/> for the defensive counterpart.
    /// </summary>
    public bool TryUsePsiSurge()
    {
        if (Psi == null)
        {
            return false;
        }

        var total = PsiPoints + DynamicAstralPsiShield + DynamicMentalPsiShield;
        if (total <= 0)
        {
            return false;
        }

        PsiPoints = 0;
        DynamicAstralPsiShield = 0;
        DynamicMentalPsiShield = 0;
        PsiSurgeAttackBonus += total * PsiSurgeAttackValuePerPoint;
        return true;
    }

    public void ClearPsiSurge() => PsiSurgeAttackBonus = 0;

    /// <summary>
    /// Megfékezés - General Diszciplína (p.118-119), defensive half of Roham (Megfékezés). Same
    /// all-or-nothing Psi-point cost as <see cref="TryUsePsiSurge"/> (including the Dinamikus
    /// Pajzs), but instead of boosting the user's own attack it subtracts 2 attack value per point
    /// from a specific opponent's attack this round. The book also has the user automatically win
    /// initiative against a non-Roham opponent when using this; that initiative-ordering rule
    /// isn't modeled here (would need to hook into the combat engine's turn-order logic).
    /// </summary>
    public bool TryUseMegfekezes(Attacker opponent)
    {
        if (Psi == null || opponent == null)
        {
            return false;
        }

        var total = PsiPoints + DynamicAstralPsiShield + DynamicMentalPsiShield;
        if (total <= 0)
        {
            return false;
        }

        PsiPoints = 0;
        DynamicAstralPsiShield = 0;
        DynamicMentalPsiShield = 0;
        opponent.AddTemporaryModifier(new CombatModifier
        {
            AttackValue = -(total * PsiSurgeAttackValuePerPoint)
        });
        return true;
    }

    /// <summary>
    /// Builds a Statikus Psi-pajzs (rulebook p.121): the points spent are a one-time cost added
    /// permanently to StaticAstralPsiShield/StaticMentalPsiShield (which already feed into
    /// Character.Magic.cs's GetAstralMagicResistance/GetMentalMagicResistance), not a pool that
    /// stays locked away — a full rest restores PsiPoints to MaxPsiPoints as normal even though the
    /// shield persists, exactly as the book describes. Only one shield per type can exist at a
    /// time (rulebook: "legfeljebb egy asztrális és egy mentális Statikus Pajzs építhető"), and
    /// once built its strength can't be changed — only removed via <see cref="RemoveStaticPsiShield"/>
    /// or torn down by Psi-ostrom (see PsiSiege/KyrPsiSiege).
    /// </summary>
    public bool TryBuildStaticPsiShield(bool isAstral, int points)
    {
        if (Psi == null || points <= 0 || points > PsiPoints)
        {
            return false;
        }

        if ((isAstral ? StaticAstralPsiShield : StaticMentalPsiShield) > 0)
        {
            return false;
        }

        PsiPoints -= points;
        if (isAstral)
        {
            StaticAstralPsiShield = points;
        }
        else
        {
            StaticMentalPsiShield = points;
        }

        return true;
    }

    /// <summary>Voluntarily dismantles a Statikus Psi-pajzs the character built themselves; only they can.</summary>
    public void RemoveStaticPsiShield(bool isAstral)
    {
        if (isAstral)
        {
            StaticAstralPsiShield = 0;
        }
        else
        {
            StaticMentalPsiShield = 0;
        }
    }

    /// <summary>
    /// Adds (positive delta) or withdraws (negative delta) points from a Dinamikus Psi-pajzs
    /// (rulebook p.121-122). Unlike the Static shield, points held in a Dynamic one "beleszámítanak
    /// a karakter aktuális Pp-jaiba" — they're moved out of PsiPoints while stored in the shield and
    /// moved back when withdrawn, so they're simply unavailable for anything else in the meantime
    /// rather than being a separate spent cost. Both shield types feed into
    /// GetAstralMagicResistance/GetMentalMagicResistance in Character.Magic.cs.
    /// </summary>
    public bool TryAdjustDynamicPsiShield(bool isAstral, int delta)
    {
        if (Psi == null || delta == 0)
        {
            return false;
        }

        var current = isAstral ? DynamicAstralPsiShield : DynamicMentalPsiShield;

        if (delta > 0)
        {
            if (delta > PsiPoints)
            {
                return false;
            }

            PsiPoints -= delta;
        }
        else
        {
            var withdrawal = -delta;
            if (withdrawal > current)
            {
                return false;
            }

            PsiPoints += withdrawal;
        }

        if (isAstral)
        {
            DynamicAstralPsiShield = current + delta;
        }
        else
        {
            DynamicMentalPsiShield = current + delta;
        }

        return true;
    }

    public override int GetPsiPoints() => PsiPoints;

    private void CalculatePsiPoints(bool isJann, ISettings? settings)
    {
        Psi = null;
        PsiPoints = 0;
        MaxPsiPoints = 0;
        PsiPointsModifier = 0;

        var cantLearnPsi = Race.SpecialQualifications.GetSpeciality<CantLearnPsi>();
        if (cantLearnPsi != null)
        {
            return;
        }

        var extraPsiPointsOnLevelUp = Race.SpecialQualifications.GetSpeciality<ExtraPsiPointOnLevelUp>();
        var extraPsiPoints = extraPsiPointsOnLevelUp == null ? 0 : extraPsiPointsOnLevelUp.ExtraPoints * BaseClass.Level;

        var currentLevel = BaseClass.Level;
        int totalPsiPoints = 0;

        var allPsiSources = Qualifications.Concat(BaseClass.FutureQualifications).OfType<IPsi>();

        var timeline = new List<PsiEvent>();
        foreach (var psi in allPsiSources)
        {
            if (psi.BaseQualificationLevel > 0 && psi.BaseQualificationLevel <= currentLevel)
            {
                var psiEvent = new PsiEvent
                {
                    Level = psi.BaseQualificationLevel,
                    Modifier = GetModifier(psi.PsiKind, QualificationLevel.Base),
                    SourceSkill = psi
                };
                if (isJann)
                {
                    psiEvent.Modifier += 1;
                }
                timeline.Add(psiEvent);
            }

            if (psi.MasterQualificationLevel > 0 && psi.MasterQualificationLevel <= currentLevel)
            {
                var psiEvent = new PsiEvent
                {
                    Level = psi.MasterQualificationLevel,
                    Modifier = GetModifier(psi.PsiKind, QualificationLevel.Master),
                    SourceSkill = psi
                };
                if (isJann)
                {
                    psiEvent.Modifier += 1;
                }
                timeline.Add(psiEvent);
            }
        }

        if (timeline.Count == 0)
        {
            return;
        }

        totalPsiPoints += MathHelper.GetAboveAverageValue(Intelligence);

        var kyrLore = Race.SpecialQualifications.GetSpeciality<KyrLore>();
        if (kyrLore != null)
        {
            totalPsiPoints += currentLevel;
        }

        bool isBasePsiInitialized = false;
        int currentBestModifier = 0;

        for (int lvl = 1; lvl <= currentLevel; lvl++)
        {
            var activeEvents = timeline.Where(e => e.Level <= lvl).ToList();
            if (activeEvents.Count == 0)
            {
                continue;
            }

            int maxModifierAtLevel = activeEvents.Max(e => e.Modifier);
            currentBestModifier = maxModifierAtLevel;
            if (maxModifierAtLevel > 0)
            {
                if (!isBasePsiInitialized)
                {
                    totalPsiPoints += maxModifierAtLevel + 1;
                    isBasePsiInitialized = true;
                }

                if (lvl > 1 || (settings?.AddPsiPointsOnFirstLevelForAllClass ?? false))
                {
                    totalPsiPoints += maxModifierAtLevel;
                }
            }
        }

        var bestEvent = timeline
            .OrderByDescending(e => e.Modifier)
            .ThenByDescending(e => e.Level)
            .FirstOrDefault();

        Psi = bestEvent?.SourceSkill;
        PsiPoints = totalPsiPoints + extraPsiPoints;
        MaxPsiPoints = totalPsiPoints + extraPsiPoints;
        PsiPointsModifier = currentBestModifier;
    }

    private static int GetModifier(PsiKind kind, QualificationLevel level)
    {
        if (kind == PsiKind.Kyr || kind == PsiKind.Monk)
        {
            return KyrModifier;
        }

        if (kind == PsiKind.Slan)
        {
            return SlanModifier;
        }

        return level == QualificationLevel.Master ? PyarronMasterModifier : PyarronBaseModifier;
    }
}
