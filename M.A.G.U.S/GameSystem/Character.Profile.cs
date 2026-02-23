using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using Mtf.Extensions.Services;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character : IHaveImage
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private IRace race;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private readonly MultiClassMode multiClassMode = MultiClassMode.Normal_Or_SwitchedClass;

    public string Birthplace { get; set; }

    public string School { get; set; }

    //public IEnumerable<Image> Images { get; set; }

    public IClass BaseClass { get; set; }

    public IClass[] Classes { get; set; }

    public string RaceName => Race.Name ?? String.Empty;

    public string Class => BaseClass.Name ?? String.Empty;

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

    public virtual string[] Images { get; set; } = [];

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string DefaultImage => Images.Length > 0 ? Images[0] : String.Empty;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string RandomImage => Images.Length > 1 ? Images[RandomProvider.GetSecureRandomInt(0, Images.Length)] : DefaultImage;
}
