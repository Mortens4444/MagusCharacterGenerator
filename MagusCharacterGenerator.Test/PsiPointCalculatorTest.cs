using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Slan;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.Test
{
    [TestFixture]
    public class PsiPointCalculatorTest
    {
        private static readonly ISettings addPsiOnFirstLevelSettings = new Settings(true);
        private static readonly ISettings doNotAddPsiOnFirstLevelSettings = new Settings(false);

        private static List<Tuple<Character, ushort>> GetTestData()
        {
            return [
                        new Tuple<Character, ushort>(new Character(addPsiOnFirstLevelSettings, "Mirena", new Human(), new Witch(5)), 25),
            new Tuple<Character, ushort>(new Character(addPsiOnFirstLevelSettings, "Toll", new Elf(), new MartialArtist(5)), 31),
            new Tuple<Character, ushort>(new Character(addPsiOnFirstLevelSettings, "Maron", new Elf(), new Wizard(5)), 37),
            new Tuple<Character, ushort>(new Character(addPsiOnFirstLevelSettings, "Vesryn (Level: 5)", new Elf(), new Headhunter(5)), 20),
            new Tuple<Character, ushort>(new Character(addPsiOnFirstLevelSettings, "Vesryn (Level: 6)", new Elf(), new Headhunter(6)), 24),

            new Tuple<Character, ushort>(new Character(doNotAddPsiOnFirstLevelSettings, "Mirena", new Human(), new Witch(5)), 21),
            new Tuple<Character, ushort>(new Character(doNotAddPsiOnFirstLevelSettings, "Toll", new Elf(), new MartialArtist(5)), 26),
            new Tuple<Character, ushort>(new Character(doNotAddPsiOnFirstLevelSettings, "Maron", new Elf(), new Wizard(5)), 31),
            new Tuple<Character, ushort>(new Character(doNotAddPsiOnFirstLevelSettings, "Vesryn (Level: 5)", new Elf(), new Headhunter(5)), 17),
            new Tuple<Character, ushort>(new Character(doNotAddPsiOnFirstLevelSettings, "Vesryn (Level: 6)", new Elf(), new Headhunter(6)), 21),
        ];
        }

        [Test]
        public void TestPsiPoints()
        {
            for (int i = 0; i < 100; i++)
            {

            List<Tuple<Character, ushort>>? testData = null;
            do
            {
                try
                {
                    testData = GetTestData();
                }
                catch { }
            }
            while (testData == null);


            foreach (var data in testData)
            {
                var character = data.Item1;
                var expectedPsiPoints = data.Item2;
                Assert.That(character.PsiPoints - (ushort)MathHelper.GetAboveAverageValue(character.Intelligence), Is.EqualTo(expectedPsiPoints));
            }
            }
        }
    }
}
