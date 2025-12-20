namespace M.A.G.U.S.Utils;

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
}
