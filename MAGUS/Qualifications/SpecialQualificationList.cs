using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Races;

namespace MAGUS.Qualifications;

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
