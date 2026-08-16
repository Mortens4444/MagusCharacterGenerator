namespace MAGUS.Utils;

public static class MathHelper
{
    public static int GetModifier(int value, int percent)
    {
        return (int)Math.Floor(value * (percent / 100.0));
    }

    public static int GetAboveAverageValue(int value)
    {
        return Math.Max(value - 10, 0);
    }

    /// <summary>Damage bonus every melee weapon (including unarmed) gets above 16 Strength: +1 per point, so 18 Strength = +2.</summary>
    public static int GetStrengthMeleeDamageBonus(int strength)
    {
        return Math.Max(strength - 16, 0);
    }
}
