using MagusCharacterGenerator.Castes.Fighter;
using MagusCharacterGenerator.Castes.Slan;
using MagusCharacterGenerator.Castes.Sorcerer;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Race;
using System;

namespace MagusCharacterGenerator
{
	class Program
    {
        static void Main(string[] args)
        {
            //Lng.ChangeToLanguage(Language.English);

            var level = (byte)6;

            var witch = new Character("Mirena", new Human(), new Witch(level));
            Console.WriteLine(witch);

            var fireWizard = new Character("Siron", new Human(), new FireWizard(level));
            Console.WriteLine(fireWizard);

            var headHunter = new Character("Vesryn", new Elf(), new Headhunter(level));
            Console.WriteLine(headHunter);

            var slan = new Character("Toll", new Elf(), new BareHandMaster(level));
            Console.WriteLine(slan);

            var wizard = new Character("Maron", new Elf(), new Wizard(level));
            Console.WriteLine(wizard);

            Console.ReadKey();
        }
    }
}
