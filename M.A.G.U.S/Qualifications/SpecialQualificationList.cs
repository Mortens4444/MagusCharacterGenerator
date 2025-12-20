using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Qualifications;

public class SpecialQualificationList : ExtendedObservableCollection<ISpecialQualification>
{
	public TSpecialQualification? GetSpeciality<TSpecialQualification>()
		where TSpecialQualification : class
	{
		return this.FirstOrDefault(specialQualification => specialQualification is TSpecialQualification) as TSpecialQualification;
	}

    public void AddFrom(IEnumerable<IClass> classes, IRace race)
    {
        AddRange(race.SpecialQualifications);
        foreach (var @class in classes)
        {
            AddRange(@class.SpecialQualifications);
        }
    }
}
