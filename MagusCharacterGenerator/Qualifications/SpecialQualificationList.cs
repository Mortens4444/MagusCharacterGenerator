using MagusCharacterGenerator.GameSystem.Qualifications;
using System.Collections.Generic;
using System.Linq;

namespace MagusCharacterGenerator.Qualifications
{
	public class SpecialQualificationList : List<ISpecialQualification>
	{
		public TSpecialQualification GetSpeciality<TSpecialQualification>()
			where TSpecialQualification : class
		{
			return this.FirstOrDefault(specialQualification => specialQualification is TSpecialQualification) as TSpecialQualification;
		}
	}
}
