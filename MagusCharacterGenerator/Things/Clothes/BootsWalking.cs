using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Clothes
{
	class BootsWalking
	{
		public string Name => "Boots, walking";

		public Money Price => new Money(0, 0, 80);

		public override string ToString() => Lng.Elem("Boots, walking");
	}
}
