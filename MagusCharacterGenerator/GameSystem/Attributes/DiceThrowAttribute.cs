using System;

namespace MagusCharacterGenerator.GameSystem.Attributes
{
	class DiceThrowAttribute : Attribute
	{
		public ThrowType DiceThrowType { get; }

		public DiceThrowAttribute(ThrowType diceThrowType)
		{
			DiceThrowType = diceThrowType;
		}
	}
}
