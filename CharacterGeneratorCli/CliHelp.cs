namespace CharacterGeneratorCli;

static class CliHelp
{
	public static void Show()
	{
		Console.WriteLine("Command line interface to generate a M.A.G.U.S. character");
		Console.WriteLine();
		Console.WriteLine("Arguments:");
		Console.WriteLine("----------");
		Console.WriteLine("-n, --name: Name of the character");
		Console.WriteLine("-c, --caste: Primary caste of the character");
		Console.WriteLine("-l, --level: Level of the primary caste");
		Console.WriteLine("-sc, --secondary-caste: Secondary caste of the character");
		Console.WriteLine("-sl, --secondary-level: Level of the secondary caste");
		Console.WriteLine("-r, --race: Race of the character");
	}
}
