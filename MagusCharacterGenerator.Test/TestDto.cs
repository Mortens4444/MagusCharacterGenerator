using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Test;

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
