using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class BootsRiding
	{
		public string Name => "Boots, riding";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Boots, riding");
	}
}
