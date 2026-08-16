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
    /// Spends psi points on a psi-surge: each point banks +2 attack value for the round
    /// currently being resolved, taking 1 segment to invoke. Available to any character with
    /// psi, regardless of discipline/school.
    /// </summary>
    public bool TryUsePsiSurge(int points)
    {
        if (Psi == null || points <= 0 || points > PsiPoints)
        {
            return false;
        }

        PsiPoints -= points;
        PsiSurgeAttackBonus += points * PsiSurgeAttackValuePerPoint;
        return true;
    }

    public void ClearPsiSurge() => PsiSurgeAttackBonus = 0;

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
