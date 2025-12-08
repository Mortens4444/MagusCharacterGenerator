using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Slan;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using NUnit.Framework.Interfaces;

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
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Mirena", new Human(), GetClass(typeof(Witch), 5)), 25),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Toll", new Elf(), GetClass(typeof(MartialArtist), 5)), 31),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Maron", new Elf(), GetClass(typeof(Wizard), 5)), 37),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Vesryn", new Elf(), GetClass(typeof(Headhunter), 5)), 20),
                new Tuple<Character, int>(new Character(addPsiOnFirstLevelSettings, "Teol", new Elf(), GetClass(typeof(Headhunter), 6)), 24),

                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Zental", new Human(), GetClass(typeof(Witch), 5)), 21),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Zover", new Elf(), GetClass(typeof(MartialArtist), 5)), 26),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Tillam", new Elf(), GetClass(typeof(Wizard), 5)), 31),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Polind", new Elf(), GetClass(typeof(Headhunter), 5)), 17),
                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Luio", new Elf(), GetClass(typeof(Headhunter), 6)), 21),

                new Tuple<Character, int>(new Character(doNotAddPsiOnFirstLevelSettings, "Gressa", new Kyr(), GetClass(typeof(Witch), 5)), 26),
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

        private static IClass GetClass(Type classType, int level)
        {
            bool hasPsi = false;
            IClass? result = null;
            do
            {
                try
                {
                    result = (IClass)Activator.CreateInstance(classType, [level]);
                    hasPsi = result.Qualifications.Any(q => q is IPsi);
                }
                catch { }
            }
            while (!hasPsi);
            return result;
        }
    }
}
