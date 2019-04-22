using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class GoodInitiator : ISpecialQualification
	{
		public byte InitiatingBase { get; }

		public GoodInitiator(byte initiatingBase)
		{
			InitiatingBase = initiatingBase;
		}
	}
}
