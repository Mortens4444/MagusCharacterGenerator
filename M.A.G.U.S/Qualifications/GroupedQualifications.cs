using System.Collections.ObjectModel;

namespace M.A.G.U.S.Qualifications;

public class GroupedQualifications(string category, IEnumerable<Qualification> qualifications) : ObservableCollection<Qualification>(qualifications)
{
    public string Category { get; } = category;
}
