using MAGUS.GameSystem.Qualifications;
using System.Collections.ObjectModel;

namespace MAGUS.Qualifications;

public class GroupedQualifications(string category, IEnumerable<Qualification> qualifications) : ObservableCollection<Qualification>(qualifications)
{
    public string Category { get; } = category;
}
