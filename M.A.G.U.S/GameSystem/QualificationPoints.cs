using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class QualificationPoints
{
    public static (ushort QualificationPoints, ushort PercentQualificationPoints) Calculate(Character character, ISettings? settings)
    {
        ushort qualificationPoints = 0;
        ushort percentQualificationPoints = 0;
        if (character.MultiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
        {
            qualificationPoints = character.BaseClass.BaseQualificationPoints;
            qualificationPoints += (ushort)MathHelper.GetAboveAverageValue(character.Intelligence);
            qualificationPoints += (ushort)MathHelper.GetAboveAverageValue(character.Dexterity);
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
