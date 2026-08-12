using System.Collections.ObjectModel;

namespace MAGUS.Qualifications;

public class ExtendedObservableCollection<T> : ObservableCollection<T>
{
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
}
