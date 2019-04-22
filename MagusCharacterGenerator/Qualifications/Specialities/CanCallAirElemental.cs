using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class CanCallAirElemental : ISpecialQualification
    {
		public byte RecallDurationInDays => 3;

		public byte ServeDurationInHour => 1;
	}
}
