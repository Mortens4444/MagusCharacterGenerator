using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class AimResolution : ResolutionBase
{
    public AimResolution(InitiativeEntry initiative, int targetDistanceMeters, MovementType movement, WeatherCondition weather)
    {
        RollValue = initiative.Attacker.Source.RollAttack();
        var aimTotal = initiative.Attacker.Source.AimValue + RollValue;

        var sizeModifier = DefenseHelper.Get(initiative.Target.Source.Size);
        var movementDefense = DefenseHelper.Get(movement);
        var weatherDefense = DefenseHelper.Get(weather);

        var defenseValue = sizeModifier + targetDistanceMeters + weatherDefense;
        
        defenseValue += initiative.Target.Source is Character character && character.SpecialQualifications.GetSpeciality<SlanDodgeAgainstRangedAttacks>() != null
            ? initiative.Target.Source.DefenseValue : 30 + movementDefense;

        IsSuccessful = aimTotal > defenseValue;
        IsHpDamage = aimTotal > defenseValue + 50;
    }
}