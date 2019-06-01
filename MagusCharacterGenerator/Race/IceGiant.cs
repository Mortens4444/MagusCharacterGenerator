﻿using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Race
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
	/// </summary>
	class IceGiant : HalfGiant
	{
		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new DressageTraining(),
						new WeatherForecast(QualificationLevel.Master)
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
						new BetterResistanceToCold(50),
						//new Sarkvidékjárás(QualificationLevel.Master)
					}
				);
				return result;
			}
		}

        public override string ToString()
        {
            return Lng.Elem("Half-giant (Ice giant)");
        }
    }
}
