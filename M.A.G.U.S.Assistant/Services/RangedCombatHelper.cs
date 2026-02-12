using M.A.G.U.S.GameSystem;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Assistant.Services;

internal static class RangedCombatHelper
{
    public record HitResult(bool IsHit, bool IsOverhit, int RollTotal, int TargetDefense);

    public static int CalculateRangedDefense(Attacker target, int distanceMeters)
    {
        var baseDef = 30;
        var sizeMod = 0;

        if (target is Character)
        {
            sizeMod = 0;
        }
        else
        {
            // egyszerű heuristika: név alapú fémpénz felismerés, különben próbáljuk lekérdezni a "Size" property-t
            var name = target.Name ?? String.Empty;
            if (name.Contains("fémpénz", StringComparison.CurrentCultureIgnoreCase) ||
                name.Contains("coin", StringComparison.CurrentCultureIgnoreCase))
            {
                sizeMod = 65;
            }
            else
            {
                var prop = target.GetType().GetProperty("Size");
                if (prop != null && prop.GetValue(target) is int si)
                {
                    sizeMod = si;
                }
            }
        }

        return baseDef + sizeMod + distanceMeters;
    }

    public static HitResult EvaluateRangedHit(Attacker attacker, Attacker target, Attack attack, int distanceMeters)
    {
        var defense = CalculateRangedDefense(target, distanceMeters);

        var ce = attacker.AimValue;

        var roll = RandomProvider.GetSecureRandomInt(1, 101);
        var total = ce + roll;

        var isHit = total > defense;
        var isOver = (total - defense) >= 50;

        return new HitResult(isHit, isOver, total, defense);
    }
}
