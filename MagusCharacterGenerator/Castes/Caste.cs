using MagusCharacterGenerator.GameSystem;

namespace MagusCharacterGenerator.Castes
{
	abstract class Caste
    {
		protected const string _1K6_Plus_12_Plus_SpecialTraining = "1K6 + 12 + Special training";

		protected readonly DiceThrow DiceThrow = new DiceThrow();

        public string Name { get; set; }

        public byte Level { get; set; }

		public Caste(byte level)
		{
			Level = level;
		}
    }
}
