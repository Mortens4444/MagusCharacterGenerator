using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int armorClass;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int armorCheckPenalty;

    public int ArmorClass
    {
        get => armorClass;
        set
        {
            if (armorClass != value)
            {
                armorClass = value;
                OnPropertyChanged();
            }
        }
    }

    public int ArmorCheckPenalty
    {
        get => armorCheckPenalty;
        set
        {
            if (armorCheckPenalty != value)
            {
                armorCheckPenalty = value;
                OnPropertyChanged();
            }
        }
    }
}
