using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Race
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/f%C3%A9lork-goblin-r67/
	/// </summary>
	class SwampGiant : HalfGiant
	{
		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new AntientLanguageKnowledge(AntientLanguage.Voul),
						//new Mocsárjárás(QualificationLevel.Master),
						new ProfessionKnowledge(Profession.Carpenter, QualificationLevel.Master),
						new ValueEstimation()
					}
				);
				return result;
			}
		}

		public override SpecialQualificationList SpecialQualifications
		{
			get
			{
				var result = base.SpecialQualifications;
				result.AddRange(
					new List<ISpecialQualification>()
					{
						new Infravision(40),
						new BetterResistanceToFire(50),
					}
				);
				return result;
			}
		}

        public override string ToString()
        {
            return Lng.Elem("Half-giant (Swamp giant)");
        }
    }
}
