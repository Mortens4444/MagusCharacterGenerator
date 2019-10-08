using System;
using System.Collections.Generic;
using MagusCharacterGenerator.Castes.Fighter;
using MagusCharacterGenerator.Castes.Slan;
using MagusCharacterGenerator.Castes.Sorcerer;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Races;
using Mtf.Helper;
using NUnit.Framework;

namespace MagusCharacterGenerator.Test
{
	[TestFixture]
    public class PsiPointCalculatorTest
    {
		public static List<Tuple<Character, ushort>> TestData = new List<Tuple<Character, ushort>>
		{
			new Tuple<Character, ushort>(new Character("Mirena", new Human(), new Witch(5)), 21),
			new Tuple<Character, ushort>(new Character("Toll", new Elf(), new BareHandMaster(5)), 26),
			new Tuple<Character, ushort>(new Character("Maron", new Elf(), new Wizard(5)), 31),
			new Tuple<Character, ushort>(new Character("Vesryn (Level: 5)", new Elf(), new Headhunter(5)), 16),
			new Tuple<Character, ushort>(new Character("Vesryn (Level: 6)", new Elf(), new Headhunter(6)), 20),
		};

		[Test]
		public void TestPsiPoints()
        {
			foreach (var data in TestData)
			{
				var character = data.Item1;
				var expectedPsiPoints = data.Item2;
				Assert.AreEqual(expectedPsiPoints, character.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(character.Intelligence));
			}

        }
    }
}
