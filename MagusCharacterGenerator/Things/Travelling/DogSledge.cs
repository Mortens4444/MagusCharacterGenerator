using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class DogSledge
	{
		public string Name => "Dog sledge";

		public Money Price => new Money(0, 8, 0);

		public override string ToString() => Lng.Elem("Dog sledge");
	}
}
