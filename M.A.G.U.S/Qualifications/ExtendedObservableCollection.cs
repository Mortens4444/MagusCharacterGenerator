using System.Collections.ObjectModel;

namespace M.A.G.U.S.Qualifications;

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
