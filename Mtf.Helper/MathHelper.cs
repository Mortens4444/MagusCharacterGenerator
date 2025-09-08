using System;

namespace Mtf.Helper
{
	public static class MathHelper
    {
        public static short GetModifier(int fightValues, byte percent)
        {
            return (short)Math.Floor(fightValues * (percent / 100.0));
        }

        public static short GetAboveAverageValue(short value)
        {
            return (short)Math.Max(value - 10, 0);
        }
    }
}
