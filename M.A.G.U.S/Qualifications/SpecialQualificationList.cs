using M.A.G.U.S.GameSystem.Qualifications;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Qualifications;

public class SpecialQualificationList : ObservableCollection<ISpecialQualification>
{
	public TSpecialQualification GetSpeciality<TSpecialQualification>()
		where TSpecialQualification : class
	{
		return this.FirstOrDefault(specialQualification => specialQualification is TSpecialQualification) as TSpecialQualification;
	}
}
