namespace CharacterGeneratorCli;

class CharacterGenerationDto
{
	public string Name { get; set; }

	public string Class { get; set; }

	public string Level { get; set; } = "1";

	public string SecondaryClass { get; set; }

	public string SecondaryLevel { get; set; } = "1";

	public string Race { get; set; }
}
