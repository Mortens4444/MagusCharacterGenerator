using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Helper;
using Mtf.Languages;
using Newtonsoft.Json;

namespace MagusCharacterGenerator.Qualifications.Laical
{
	class ProfessionKnowledge : Qualification
    {
        public Profession Profession { get; set; }

		[JsonConstructor]
		public ProfessionKnowledge() { }

		public ProfessionKnowledge(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

		public ProfessionKnowledge(Profession profession, QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
			: base(qualificationLevel, level)
		{
			Profession = profession;
		}

		public override string ToString() => $"{Lng.Elem("Profession")} ({Lng.Elem(EnumUtils.GetDescription(Profession))})";
    }
}
