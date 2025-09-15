namespace CharacterGeneratorCli;

class CommandLineArgumentsParser
{
	public CharacterGenerationDto? Parse(string[] args)
	{
		try
		{
			var result = new CharacterGenerationDto();

			int i = 0;
			while (i < args.Length)
			{
				switch (args[i].ToLower())
				{
					case "-n":
					case "--name":
						result.Name = args[++i].ToLower();
						break;

					case "-c":
					case "--caste":
						result.Caste = args[++i].ToLower();
						break;

					case "-l":
					case "--level":
						result.Level = args[++i].ToLower();
						break;

					case "-sc":
					case "--secondary-caste":
						result.SecondaryCaste = args[++i].ToLower();
						break;

					case "-sl":
					case "--secondary-level":
						result.SecondaryLevel = args[++i].ToLower();
						break;

					case "-r":
					case "--race":
						result.Race = args[++i].ToLower();
						break;
				}

				i++;
			}
			return result;
		}
		catch (Exception)
		{
			CliHelp.Show();
			return null;
		}
	}
}
