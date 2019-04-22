using System;

namespace Mtf.Helper
{
	public static class RandomGenerator
    {
        private static readonly Random random = new Random();

        public static short Get(short min = short.MinValue, short max = short.MaxValue)
        {
            return (short)random.Next(min, max + 1);
        }
    }
}
