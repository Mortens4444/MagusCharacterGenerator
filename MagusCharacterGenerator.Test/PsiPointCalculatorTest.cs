using MagusCharacterGenerator.Castes.Fighter;
using MagusCharacterGenerator.Castes.Slan;
using MagusCharacterGenerator.Castes.Sorcerer;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Race;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mtf.Helper;

namespace MagusCharacterGenerator.Test
{
	[TestClass]
    public class PsiPointCalculatorTest
    {
        [TestMethod]
        public void TestPsiPoints()
        {
            var witch = new Character("Mirena", new Human(), new Witch(5));
            Assert.AreEqual(witch.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(witch.Intelligence), 21);

            var slan = new Character("Toll", new Elf(), new BareHandMaster(5));
            Assert.AreEqual(slan.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(slan.Intelligence), 26);

            var wizard = new Character("Maron", new Elf(), new Wizard(5));
            Assert.AreEqual(wizard.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(wizard.Intelligence), 31);

            var headHunter1 = new Character("Vesryn (Level: 5)", new Elf(), new Headhunter(5));
            Assert.AreEqual(headHunter1.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(headHunter1.Intelligence), 16);

            var headHunter2 = new Character("Vesryn (Level: 6)", new Elf(), new Headhunter(6));
            Assert.AreEqual(headHunter2.PsiPoints - (ushort)MathHelper.GetAboveAvarageValue(headHunter2.Intelligence), 20);
        }
    }
}
