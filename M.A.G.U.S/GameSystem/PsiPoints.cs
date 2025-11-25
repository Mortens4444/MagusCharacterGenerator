using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class PsiPoints
{
    public const byte KyrModifier = 6;
    public const byte SlanModifier = 5;
    public const byte PyarronMasterModifier = 4;
    public const byte PyarronBaseModifier = 3;

    public static PsiAttributes Calculate(Character character, ISettings settings)
    {
        var currentLevel = character.BaseClass.Level;
        ushort totalPsiPoints = 0;

        var allPsiSources = character.Qualifications.Concat(character.BaseClass.FutureQualifications)
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

        if (!timeline.Any())
        {
            return new PsiAttributes { Psi = null, PsiPoints = 0, PsiPointsModifier = 0 };
        }

        totalPsiPoints += (ushort)MathHelper.GetAboveAverageValue(character.Intelligence);

        var kyrLore = character.Race.SpecialQualifications.GetSpeciality<KyrLore>();
        if (kyrLore != null)
        {
            totalPsiPoints += currentLevel;
        }

        bool isBasePsiInitialized = false;
        byte currentBestModifier = 0;

        for (byte lvl = 1; lvl <= currentLevel; lvl++)
        {
            var activeEvents = timeline.Where(e => e.Level <= lvl).ToList();
            if (!activeEvents.Any())
            {
                continue;
            }

            byte maxModifierAtLevel = activeEvents.Max(e => e.Modifier);
            currentBestModifier = maxModifierAtLevel;
            if (maxModifierAtLevel > 0)
            {
                if (!isBasePsiInitialized)
                {
                    totalPsiPoints += (ushort)(maxModifierAtLevel + 1);
                    isBasePsiInitialized = true;
                }

                if (lvl > 1 || settings.AddPsiPointsOnFirstLevelForAllClass)
                {
                    totalPsiPoints += maxModifierAtLevel;
                }
            }
        }

        var bestEvent = timeline
            .OrderByDescending(e => e.Modifier)
            .ThenByDescending(e => e.Level)
            .FirstOrDefault();

        return new PsiAttributes
        {
            Psi = bestEvent?.SourceSkill,
            PsiPoints = totalPsiPoints,
            PsiPointsModifier = currentBestModifier
        };
    }

    private static byte GetModifier(PsiKind kind, QualificationLevel level)
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