using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Other
{
	class FabricEll
	{
		public string Name => "Fabric, ell";

		public Money Price => new Money(0, 0, 30);

		public override string ToString() => Lng.Elem("Fabric, ell");
	}
}
