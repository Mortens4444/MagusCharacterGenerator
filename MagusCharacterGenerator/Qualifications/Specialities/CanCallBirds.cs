using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class CanCallBirds : ISpecialQualification
    {
		public byte RecallDurationInMinutes => 30;

		public byte ServeDurationInHour => 1;
	}
}
