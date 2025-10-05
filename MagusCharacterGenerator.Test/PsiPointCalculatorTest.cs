using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Slan;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.Test
{
	[TestFixture]
    public class PsiPointCalculatorTest
    {
		public static List<Tuple<Character, ushort>> TestData = new List<Tuple<Character, ushort>>
		{
			new Tuple<Character, ushort>(new Character("Mirena", new Human(), new Witch(5)), 20),
			new Tuple<Character, ushort>(new Character("Toll", new Elf(), new MartialArtist(5)), 26),
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
				Assert.That(character.PsiPoints - (ushort)MathHelper.GetAboveAverageValue(character.Intelligence), Is.EqualTo(expectedPsiPoints));
			}
        }
    }
}
