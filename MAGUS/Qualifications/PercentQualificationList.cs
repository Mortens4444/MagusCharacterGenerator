using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications.Percentages;
using MAGUS.Utils;

namespace MAGUS.Qualifications;

public class PercentQualificationList : ExtendedObservableCollection<PercentQualification>
{
    public void AddIfNotExists<T>(T percentQualification) where T : PercentQualification
    {
        if (this.FirstOrDefault(pq => pq is T) == null)
        {
            Add(percentQualification);
        }
    }

    public void AddFrom(IEnumerable<IClass> classes, int dexterity)
    {
        foreach (var @class in classes)
        {
            AddRange(@class.PercentQualifications);
        }
        AddIfNotExists(new Falling(0));
        AddIfNotExists(new Climbing(0));
        AddIfNotExists(new Jumping(0));
        var dexterityBasedPercentages = new List<Type> { typeof(Falling), typeof(Climbing), typeof(Jumping) };
        foreach (var percentQualification in this)
        {
            if (dexterityBasedPercentages.Contains(percentQualification.GetType()))
            {
                percentQualification.Percent += MathHelper.GetAboveAverageValue(dexterity);
            }
        }
    }
}
