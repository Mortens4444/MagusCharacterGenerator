using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfPyarron
{
	class DreinaPaladin : Paladin
    {
        public DreinaPaladin(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new HistoryKnowledge(),
						new Leadership(),
						new Cartography(),
						new Heraldry()
					}
				);
				return result;
			}
		}

		public override QualificationList FutureQualifications
		{
			get
			{
				var result = base.FutureQualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new Cartography(level: 4)
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Dreina paladin");
    }
}
