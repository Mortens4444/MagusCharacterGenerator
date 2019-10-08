using System;
using System.Linq;
using System.Reflection;
using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.Races;
using MagusCharacterGenerator.Utils;
using Mtf.Helper;
using Mtf.Languages;

namespace CharacterGeneratorCli
{
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
				characterGenerationDto.Name = NameGenerator.Get().ToName();
			}

			var character = Generate(characterGenerationDto);
			Console.WriteLine(character.ToString());
			Console.ReadKey();
		}

		private static Character Generate(CharacterGenerationDto characterGenerationDto)
		{
			try
			{
				var magusCharacterGeneratorTypes = Assembly.Load("MagusCharacterGenerator").GetTypes();
				var races = magusCharacterGeneratorTypes
					.Where(type => !type.IsInterface && !type.IsAbstract && typeof(IRace).IsAssignableFrom(type))
					.Select(raceType => (IRace)Activator.CreateInstance(raceType));
				var selectedRace = races.First(race => race.ToString().ToLower() == characterGenerationDto.Race);

				var castes = magusCharacterGeneratorTypes
					.Where(type => !type.IsAbstract && typeof(ICaste).IsAssignableFrom(type))
					.Select(casteType => (ICaste)Activator.CreateInstance(casteType, (byte)1));
				var selectedCaste = castes.First(caste => caste.ToString().ToLower() == characterGenerationDto.Caste);

				var primaryCatse = (ICaste)Activator.CreateInstance(selectedCaste.GetType(), Convert.ToByte(characterGenerationDto.Level));
				Character character;
				if (!String.IsNullOrEmpty(characterGenerationDto.SecondaryCaste))
				{
					var secondarySelectedCaste = castes.First(caste => caste.ToString().ToLower() == characterGenerationDto.SecondaryCaste);
					var secondaryCaste = (ICaste)Activator.CreateInstance(secondarySelectedCaste.GetType(), Convert.ToByte(characterGenerationDto.SecondaryLevel));
					character = (Character)Activator.CreateInstance(typeof(Character), characterGenerationDto.Name, selectedRace, primaryCatse, secondaryCaste);
				}
				else
				{
					character = (Character)Activator.CreateInstance(typeof(Character), characterGenerationDto.Name, selectedRace, primaryCatse);
				}
				character.CalculateChanges();
				return character;
			}
			catch
			{
				return Generate(characterGenerationDto);
			}
		}
	}
}
