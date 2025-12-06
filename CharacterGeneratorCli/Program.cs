using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using System.Reflection;

namespace CharacterGeneratorCli;

class Program
{
	static void Main(string[] args)
	{
		if (args.Length < 4 || args.Length > 12)
		{
			CliHelp.Show();
			return;
		}

		var argsParser = new CommandLineArgumentsParser();
		var characterGenerationDto = argsParser.Parse(args);
		if (characterGenerationDto == null)
		{
			CliHelp.Show();
			return;
		}

		if (String.IsNullOrEmpty(characterGenerationDto.Name))
		{
			characterGenerationDto.Name = NameGenerator.Get(null).ToName();
		}

		var character = Generate(characterGenerationDto);
		Console.WriteLine(character.ToString());
		Console.ReadKey();
	}

	private static Character Generate(CharacterGenerationDto characterGenerationDto)
	{
		try
		{
			var magusCharacterGeneratorTypes = Assembly.Load("M.A.G.U.S.").GetTypes();
			var races = magusCharacterGeneratorTypes
				.Where(type => !type.IsInterface && !type.IsAbstract && typeof(IRace).IsAssignableFrom(type))
				.Select(raceType => (IRace)Activator.CreateInstance(raceType));
			var selectedRace = races.First(race => race.ToString().ToLower() == characterGenerationDto.Race);

			var classes = magusCharacterGeneratorTypes
				.Where(type => !type.IsAbstract && typeof(IClass).IsAssignableFrom(type))
				.Select(classType => (IClass)Activator.CreateInstance(classType, 1));
			var selectedClass = classes.First(@class => @class.ToString().ToLower() == characterGenerationDto.Class);

			var primaryClass = (IClass)Activator.CreateInstance(selectedClass.GetType(), Convert.ToByte(characterGenerationDto.Level));
			Character character;
			if (!String.IsNullOrEmpty(characterGenerationDto.SecondaryClass))
			{
				var secondarySelectedClass = classes.First(@class => @class.ToString().ToLower() == characterGenerationDto.SecondaryClass);
				var secondaryClass = Activator.CreateInstance(secondarySelectedClass.GetType(), Convert.ToByte(characterGenerationDto.SecondaryLevel)) as IClass;
				character = Activator.CreateInstance(typeof(Character), characterGenerationDto.Name, selectedRace, primaryClass, secondaryClass) as Character ?? throw new InvalidOperationException();
			}
			else
			{
				character = Activator.CreateInstance(typeof(Character), characterGenerationDto.Name, selectedRace, primaryClass) as Character ?? throw new InvalidOperationException();
			}
			character?.CalculateChanges();
			return character;
		}
		catch
		{
			return Generate(characterGenerationDto);
		}
	}
}
