using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Trappings
{
	class PackSaddle
	{
		public string Name => "Pack saddle";

		public Money Price => new Money(0, 2, 0);

		public override string ToString() => Lng.Elem("Pack saddle");
	}
}
