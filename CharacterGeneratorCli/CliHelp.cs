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
		Console.WriteLine("-c, --class: Primary class of the character");
		Console.WriteLine("-l, --level: Level of the primary class");
		Console.WriteLine("-sc, --secondary-class: Secondary class of the character");
		Console.WriteLine("-sl, --secondary-level: Level of the secondary class");
		Console.WriteLine("-r, --race: Race of the character");
	}
}
