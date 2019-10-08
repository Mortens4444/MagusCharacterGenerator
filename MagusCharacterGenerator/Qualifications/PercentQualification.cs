using System;

namespace MagusCharacterGenerator.Qualifications
{
	public class PercentQualification
    {
        protected readonly byte Percent;

        public PercentQualification(byte percent)
        {
            Percent = percent;
        }

		public string ToFullString()
		{
			return String.Concat(ToString(), $" {Percent}%");
		}
	}
}
