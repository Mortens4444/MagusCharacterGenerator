using MagusCharacterGenerator.GameSystem.Valuables;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Travelling
{
	class PostChaiseForADay
	{
		public string Name => "Post chaise for a day";

		public Money Price => new Money(0, 0, 60);

		public override string ToString() => Lng.Elem("Post chaise for a day");
	}
}
