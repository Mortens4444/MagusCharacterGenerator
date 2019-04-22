using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class CanFly : ISpecialQualification
    {
		private readonly DiceThrow diceThrow = new DiceThrow();

		public byte FlyingSpeed => (byte)(60 + diceThrow._1K10());
	}
}
