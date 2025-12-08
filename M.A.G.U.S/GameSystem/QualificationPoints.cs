using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class QualificationPoints
{
    public static (int QualificationPoints, int PercentQualificationPoints) Calculate(Character character, ISettings? settings)
    {
        int qualificationPoints = 0;
        int percentQualificationPoints = 0;
        if (character.MultiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
        {
            qualificationPoints = character.BaseClass.BaseQualificationPoints;
            qualificationPoints += MathHelper.GetAboveAverageValue(character.Intelligence); // Can only be spent on scientific qualifications
            qualificationPoints += MathHelper.GetAboveAverageValue(character.Dexterity); // Can only be spent on non-scientific qualifications
            if (character.BaseClass.AddQualificationPointsOnFirstLevel || (settings?.AddQualificationPointsOnFirstLevelForAllClass ?? true))
            {
                qualificationPoints += character.BaseClass.QualificationPointsModifier;
            }
            for (int i = 1; i < character.BaseClass.Level; i++)
            {
                qualificationPoints += character.BaseClass.QualificationPointsModifier;
                percentQualificationPoints += character.BaseClass.PercentQualificationModifier;
            }
        }
        else
        {
            // TwinClass
            // When it got the new class?
            throw new NotImplementedException();
        }

        return (qualificationPoints, percentQualificationPoints);
    }
}
