using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public static class FightValues
{
    public static FightModifier Calculate(Character character)
    {
        var result = new FightModifier();
        var initiatorRace = character.Race.SpecialQualifications.GetSpeciality<GoodInitiator>();

        result.InitiatingValue = initiatorRace != null ? initiatorRace.InitiatingBase : character.BaseClass.InitiatingBaseValue;
        result.InitiatingValue += MathHelper.GetAboveAverageValue(character.Quickness);
        result.InitiatingValue += MathHelper.GetAboveAverageValue(character.Dexterity);

        result.AttackingValue = character.BaseClass.AttackingBaseValue;
        result.AttackingValue += MathHelper.GetAboveAverageValue(character.Strength);
        result.AttackingValue += MathHelper.GetAboveAverageValue(character.Quickness);
        result.AttackingValue += MathHelper.GetAboveAverageValue(character.Dexterity);

        result.DefendingValue = character.BaseClass.DefendingBaseValue;
        result.DefendingValue += MathHelper.GetAboveAverageValue(character.Quickness);
        result.DefendingValue += MathHelper.GetAboveAverageValue(character.Dexterity);

        var archerClass = character.BaseClass.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
        var archerRace = character.Race.SpecialQualifications.GetSpeciality<GoodArcher>();

        try
        {
            result.AimingValue = archerClass != null ? archerClass.AimingBase :
                archerRace != null ? archerRace.AimingBase : character.BaseClass.AimingBaseValue;
            result.AimingValue += MathHelper.GetAboveAverageValue(character.Dexterity);
        }
        catch (InvalidOperationException)
        {
            result.AimingValue = 0;
        }

        var (attackPercentage, defencePercentage, aimingPercentage) = DistributionProvider.Get(character.BaseClass, character.Race);
        var levelUpFightModifier = Calculate(character.BaseClass, attackPercentage, defencePercentage, aimingPercentage);
        result.InitiatingValue += levelUpFightModifier.InitiatingValue;
        result.AttackingValue += levelUpFightModifier.AttackingValue;
        result.DefendingValue += levelUpFightModifier.DefendingValue;
        result.AimingValue += levelUpFightModifier.AimingValue;
        return result;
    }

    private static FightModifier Calculate(IClass @class, byte attackPercentage, byte defencePercentage, byte aimingPercentage)
    {
        var fightValues = (@class.AddFightValueOnFirstLevel ? @class.Level : @class.Level - 1) * @class.FightValueModifier;
        var attackPoints = MathHelper.GetModifier(fightValues, attackPercentage);
        var defencePoints = MathHelper.GetModifier(fightValues, defencePercentage);
        var aimingPoints = MathHelper.GetModifier(fightValues, aimingPercentage);
        var initiatorPoints = (short)(fightValues - attackPoints - defencePoints - aimingPoints);
        if (initiatorPoints < 0)
        {
            throw new InvalidOperationException($"The amount of the percentages ({nameof(attackPercentage)} + {nameof(defencePercentage)} + {nameof(aimingPercentage)}) should be under or equal to 100 percent.");
        }

        return new FightModifier()
        {
            InitiatingValue = initiatorPoints,
            AttackingValue = attackPoints,
            DefendingValue = defencePoints,
            AimingValue = aimingPoints
        };
    }
}
