using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications;

public class SpecialQualificationList : List<ISpecialQualification>
{
	public TSpecialQualification GetSpeciality<TSpecialQualification>()
		where TSpecialQualification : class
	{
		return this.FirstOrDefault(specialQualification => specialQualification is TSpecialQualification) as TSpecialQualification;
	}
}
