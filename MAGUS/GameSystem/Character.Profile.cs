using MAGUS.Enums;
using MAGUS.GameSystem.Places;
using MAGUS.Interfaces;
using MAGUS.Races;
using Mtf.Extensions.Services;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character : IHaveImage
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private IRace race;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private readonly MultiClassMode multiClassMode = MultiClassMode.Normal_Or_SwitchedClass;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private City? currentLocation;

    // Birthplace used to be a free-text string that nothing in the UI ever actually set, so existing
    // saved characters may have a JSON null here; NullValueHandling.Ignore keeps that from throwing
    // during deserialization (Newtonsoft otherwise fails converting a null token into a non-nullable
    // enum) - it just leaves the default City.Unknown instead.
    [Newtonsoft.Json.JsonProperty(NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public City Birthplace { get; set; }

    /// <summary>
    /// Where the character actually is right now, as of their last Travel action (see
    /// Places/TravelCalculator.cs). Falls back to Birthplace until they've traveled at least once,
    /// so a freshly-created character needs no separate initialization step.
    /// </summary>
    public City CurrentLocation
    {
        get => currentLocation ?? Birthplace;
        set
        {
            if (currentLocation != value)
            {
                currentLocation = value;
                OnPropertyChanged();
            }
        }
    }

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

    private string[] images = [];

    public virtual string[] Images
    {
        get => images;
        set
        {
            if (images != value)
            {
                images = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DefaultImage));
                OnPropertyChanged(nameof(RandomImage));
            }
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string DefaultImage => Images.Length > 0 ? Images[0] : String.Empty;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string RandomImage => Images.Length > 1 ? Images[RandomProvider.GetSecureRandomInt(0, Images.Length)] : DefaultImage;
}
