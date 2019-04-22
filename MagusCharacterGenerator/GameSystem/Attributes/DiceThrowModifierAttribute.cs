using System;

namespace MagusCharacterGenerator.GameSystem.Attributes
{
	class DiceThrowModifierAttribute : Attribute
	{
		public byte Modifier { get; }

		public DiceThrowModifierAttribute(byte modifier)
		{
			Modifier = modifier;
		}
	}
}
