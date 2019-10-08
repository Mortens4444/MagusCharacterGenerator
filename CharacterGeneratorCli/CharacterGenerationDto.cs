namespace CharacterGeneratorCli
{
	class CharacterGenerationDto
	{
		public string Name { get; set; }

		public string Caste { get; set; }

		public string Level { get; set; } = "1";

		public string SecondaryCaste { get; set; }

		public string SecondaryLevel { get; set; } = "1";

		public string Race { get; set; }
	}
}
