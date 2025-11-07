using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class ManaPoints
{
    public static SorceryAttributes Calculate(Character character)
    {
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
                for (int i = 1; i < @class.Level; i++)
                {
                    manaPoints += sorcery.GetManaPointsModifier();
                }
                //maxManaPointsPerLevel = sorcery.GetManaPointsModifier();

                if (result.ManaPoints < manaPoints)
                {
                    result = new SorceryAttributes
                    {
                        ManaPoints = manaPoints,
                        MaxManaPointsPerLevel = sorcery.GetManaPointsModifier(),
                        Sorcery = sorcery
                    };
                }
            }
        }
        return result;
    }
}