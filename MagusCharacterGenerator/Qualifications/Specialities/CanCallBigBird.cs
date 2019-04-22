using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class CanCallBigBird : ISpecialQualification
    {
		public byte RecallDurationInDays => 1;

		public byte ServeDurationInHour => 1;
	}
}
