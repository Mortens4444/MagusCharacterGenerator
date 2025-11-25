using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class PainTolerancePoints
{
    public static short Calculate(Character character, ISettings settings)
    {
        short painTolerancePoints = 0;
        var doubledPainToleranceBase = character.Race.SpecialQualifications.GetSpeciality<DoubledPainToleranceBase>();
        if (character.MultiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
        {
            painTolerancePoints = doubledPainToleranceBase != null ? (byte)(2 * character.BaseClass.BasePainTolerancePoints) : character.BaseClass.BasePainTolerancePoints;
            painTolerancePoints += MathHelper.GetAboveAverageValue(character.Stamina);
            painTolerancePoints += MathHelper.GetAboveAverageValue(character.Willpower);
            if (character.BaseClass.AddPainToleranceOnFirstLevel || settings.AddPainToleranceOnFirstLevelForAllClass)
            {
                painTolerancePoints += character.BaseClass.GetPainToleranceModifier();
            }

            for (int i = 1; i < character.BaseClass.Level; i++)
            {
                painTolerancePoints += character.BaseClass.GetPainToleranceModifier();
            }
        }
        else
        {
            throw new NotImplementedException();
        }

        return painTolerancePoints;
    }
}
