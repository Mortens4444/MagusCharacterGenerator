using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    private IRace race;
    private readonly MultiClassMode multiClassMode = MultiClassMode.Normal_Or_SwitchedClass;

    public string Birthplace { get; set; }

    public string School { get; set; }

    public Alignment Alignment { get; set; }

    //public IEnumerable<Image> Images { get; set; }

    public IClass BaseClass { get; set; }

    public IClass[] Classes { get; set; }

    public string RaceName => Race.Name ?? String.Empty;

    public string Class => BaseClass.Name ?? String.Empty;

    public int Level => BaseClass.Level;

    public MultiClassMode MultiClassMode => multiClassMode;

    public IRace Race
    {
        get => race;
        set
        {
            if (race != value)
            {
                race = value;
                OnPropertyChanged();
            }
        }
    }
}
