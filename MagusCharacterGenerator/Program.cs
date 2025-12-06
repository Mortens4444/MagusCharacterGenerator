using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Slan;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Races;
using M.A.G.U.S.Test;

namespace MagusCharacterGenerator
{
	class Program
    {
        static void Main(string[] args)
        {
            //Lng.ChangeToLanguage(Language.English);

            var level = 6;
            var witch = new Character(new Settings(), "Mirena", new Human(), new Witch(level));
            Console.WriteLine(witch);

            var fireWizard = new Character(new Settings(), "Siron", new Human(), new FireWizard(level));
            Console.WriteLine(fireWizard);

            var headHunter = new Character(new Settings(), "Vesryn", new Elf(), new Headhunter(level));
            Console.WriteLine(headHunter);

            var slan = new Character(new Settings(), "Toll", new Elf(), new MartialArtist(level));
            Console.WriteLine(slan);

            var wizard = new Character(new Settings(), "Maron", new Elf(), new Wizard(level));
            Console.WriteLine(wizard);

            Console.ReadKey();
        }
    }
}
