using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

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

    private void CalculatePsiPoints(ISettings? settings)
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

        var allPsiSources = Qualifications.Concat(BaseClass.FutureQualifications)
                                                    .OfType<IPsi>();

        var timeline = new List<PsiEvent>();
        foreach (var psi in allPsiSources)
        {
            if (psi.BaseQualificationLevel > 0 && psi.BaseQualificationLevel <= currentLevel)
            {
                timeline.Add(new PsiEvent
                {
                    Level = psi.BaseQualificationLevel,
                    Modifier = GetModifier(psi.PsiKind, QualificationLevel.Base),
                    SourceSkill = psi
                });
            }

            if (psi.MasterQualificationLevel > 0 && psi.MasterQualificationLevel <= currentLevel)
            {
                timeline.Add(new PsiEvent
                {
                    Level = psi.MasterQualificationLevel,
                    Modifier = GetModifier(psi.PsiKind, QualificationLevel.Master),
                    SourceSkill = psi
                });
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
        if (kind == PsiKind.Kyr)
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
