using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem.Psi;

public static class PsiPointCalculator
{
    public static (IPsi Psi, ushort PsiPoints, byte PsiPointsModifier) Calculate(QualificationList qualifications, short intelligence, byte level)
    {
        ushort psiPoints = 0;
        byte psiPointsModifier = 0;
        var psi = qualifications.FirstOrDefault(qualification => qualification is IPsi) as IPsi;
        if (psi != null)
        {
            psiPoints += (ushort)MathHelper.GetAboveAverageValue(intelligence);
            if (psi.PsiKind == PsiKind.Kyr)
            {
                psiPointsModifier = PsiUtils.KyrModifier;
                psiPoints += PsiUtils.GetPsiPoints(PsiUtils.KyrModifier, level);
            }
            else if (psi.PsiKind == PsiKind.Slan)
            {
                psiPointsModifier = PsiUtils.SlanModifier;
                psiPoints += PsiUtils.GetPsiPoints(PsiUtils.SlanModifier, level);

            }
            else if (psi.QualificationLevel == QualificationLevel.Master)
            {
                psiPointsModifier = PsiUtils.PyarronMasterModifier;

                var basePsiPoints = PsiUtils.GetPsiPoints(PsiUtils.PyarronBaseModifier, psi.MasterQualificationLevel, psi.BaseQualificationLevel);
                psiPoints += basePsiPoints;
                                   
                var masterPsiPoints = basePsiPoints == 0 ?
                    PsiUtils.GetPsiPoints(PsiUtils.PyarronMasterModifier, level, psi.MasterQualificationLevel) :
                    PsiUtils.GetPsiPoints(PsiUtils.PyarronMasterModifier, level - psi.MasterQualificationLevel);
                psiPoints += masterPsiPoints;

                if ((basePsiPoints > 0) && (masterPsiPoints > 0))
                {
                    // In this case the AdditionalPsiBase added two times.
                    psiPoints -= PsiUtils.AdditionalPsiBase;
                }
            }
            else
            {
                psiPointsModifier = PsiUtils.PyarronBaseModifier;
                psiPoints += PsiUtils.GetPsiPoints(PsiUtils.PyarronBaseModifier, level, psi.BaseQualificationLevel);
            }
        }
        return (psi, psiPoints, psiPointsModifier);
    }
}
