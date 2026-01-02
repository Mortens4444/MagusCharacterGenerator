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

        private static List<Tuple<Character, int>> GetTestData()
        {
            return
            [
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Mirena", new Human(), ClassCreator.GetClass(typeof(Witch), 5)), 25),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Toll", new Elf(), ClassCreator.GetClass(typeof(MartialArtist), 5)), 31),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Maron", new Elf(), ClassCreator.GetClass(typeof(Wizard), 5)), 37),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Vesryn", new Elf(), ClassCreator.GetClass(typeof(Assassin), 5)), 20),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Teol", new Elf(), ClassCreator.GetClass(typeof(Assassin), 6)), 24),

                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Zental", new Human(), ClassCreator.GetClass(typeof(Witch), 5)), 21),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Zover", new Elf(), ClassCreator.GetClass(typeof(MartialArtist), 5)), 26),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Tillam", new Elf(), ClassCreator.GetClass(typeof(Wizard), 5)), 31),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Polind", new Elf(), ClassCreator.GetClass(typeof(Assassin), 5)), 17),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Luio", new Elf(), ClassCreator.GetClass(typeof(Assassin), 6)), 21),

                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Gressa", new Kyr(), ClassCreator.GetClass(typeof(Witch), 5)), 26),
            ];
        }

        [Test]
        public void TestPsiPoints()
        {
            List<Tuple<Character, int>>? testData = null;
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
                Assert.That(character.PsiPoints - MathHelper.GetAboveAverageValue(character.Intelligence), Is.EqualTo(expectedPsiPoints), character.Name);
            }
        }
    }
}
