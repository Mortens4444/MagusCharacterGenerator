using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class ManaPoints
{
    public static SorceryAttributes Calculate(Character character, ISettings? settings)
    {
        var extraManaPointsOnLevelUp = character.Race.SpecialQualifications.GetSpeciality<ExtraManaPointOnLevelUp>();
        var extraManaPoints = extraManaPointsOnLevelUp == null ? 0 : extraManaPointsOnLevelUp.ExtraManaPoints * character.BaseClass.Level;

        var kyrLore = character.Race.SpecialQualifications.GetSpeciality<KyrLore>();

        var result = new SorceryAttributes
        {
            ManaPoints = 0,
            MaxManaPointsPerLevel = 0,
            Sorcery = null
        };
        //ushort maxManaPointsPerLevel = 0;
        foreach (var @class in character.Classes)
        {
            var sorcery = @class.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is Sorcery) as Sorcery;
            if (sorcery != null)
            {
                if (character.BaseClass is Bard)
                {
                    sorcery.ManaPoints = (ushort)MathHelper.GetAboveAverageValue(character.Intelligence);
                }
                var manaPoints = sorcery.ManaPoints;
                if (kyrLore != null)
                {
                    manaPoints += character.BaseClass.Level;
                }
                for (int lvl = 1; lvl <= @class.Level; lvl++)
                {
                    if (lvl > 1 || (settings?.AddManaPointsOnFirstLevelForAllClass ?? false))
                    {
                        manaPoints += sorcery.GetManaPointsModifier();
                    }
                }
                //maxManaPointsPerLevel = sorcery.GetManaPointsModifier();

                if (result.ManaPoints < manaPoints)
                {
                    result = new SorceryAttributes
                    {
                        ManaPoints = (ushort)(manaPoints + extraManaPoints),
                        MaxManaPointsPerLevel = sorcery.GetManaPointsModifier(),
                        Sorcery = sorcery
                    };
                }
            }
        }
        return result;
    }
}