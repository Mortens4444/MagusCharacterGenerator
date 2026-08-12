using MAGUS.GameSystem;
using MAGUS.Interfaces;
using MAGUS.Qualifications.Scientific;
using MAGUS.Races;

namespace MAGUS.Test;

public class TestDto
{
    public int Value { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public List<int> Lst { get; set; }
    public LanguageLore Lng { get; set; }
    public IClass Class { get; set; }
    public IRace Race { get; set; }
    public Character Character { get; set; }
}
