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
		public static object[] TestData =
		{
			new object[] { new Character("Mirena", new Human(), new Witch(5)), (ushort)21 },
			new object[] { new Character("Toll", new Elf(), new BareHandMaster(5)), (ushort)26 },
			new object[] { new Character("Maron", new Elf(), new Wizard(5)), (ushort)31 },
			new object[] { new Character("Vesryn (Level: 5)", new Elf(), new Headhunter(5)), (ushort)16 },
			new object[] { new Character("Vesryn (Level: 6)", new Elf(), new Headhunter(6)), (ushort)20 },
		};

		[Test, TestCaseSource("TestData")]
		public void TestPsiPoints(Character character, ushort expectedPsiPoints)
        {
            Assert.AreEqual(expectedPsiPoints, character.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(character.Intelligence));
        }
    }
}
