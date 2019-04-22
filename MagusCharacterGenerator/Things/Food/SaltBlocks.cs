using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Food
{
	class SaltBlocks
	{
		public string Name => "Salt, blocks";

		public Money Price => new Money(0, 0, 1);

		public override string ToString() => Lng.Elem("Salt, blocks");
	}
}
