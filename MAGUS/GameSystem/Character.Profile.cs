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

    /// <summary>
    /// The character's precise (X, Y) position in the same coordinate space as CityCoordinates -
    /// unlike CurrentLocation, which only names a settlement, this also holds while traveling (the
    /// point the current journey departed from - see CurrentTravelPosition for the live interpolated
    /// point) and after StopTraveling (exactly where they stopped, not a random or unknown spot). Null
    /// only for a character who has never traveled and has no known Birthplace yet - a legitimately
    /// unknown starting point, not something TravelAsync should paper over by guessing a city.
    /// </summary>
    public WorldPosition? Position { get; set; }

    /// <summary>Destination of a journey in progress, started via Travel (CharacterViewModel.TravelAsync). Null when not traveling.</summary>
    public City? TravelDestination { get; set; }

    /// <summary>When the current journey started, in UTC - used with TravelDurationDays to compute TravelProgress against wall-clock time.</summary>
    public DateTime? TravelDepartureUtc { get; set; }

    /// <summary>How many days the current journey takes in total (TravelCalculator.CalculateDays at the moment of departure).</summary>
    public double TravelDurationDays { get; set; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool IsTraveling => TravelDestination.HasValue;

    /// <summary>0 (just departed) to 1 (arrived), based on how much of TravelDurationDays has elapsed in real time since TravelDepartureUtc.</summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public double TravelProgress
    {
        get
        {
            if (TravelDestination is null || TravelDepartureUtc is not { } departure || TravelDurationDays <= 0)
            {
                return 0;
            }

            var elapsedDays = (DateTime.UtcNow - departure).TotalDays;
            return Math.Clamp(elapsedDays / TravelDurationDays, 0, 1);
        }
    }

    /// <summary>
    /// The character's live position while traveling - Position (where the journey departed from)
    /// linearly interpolated toward the destination's coordinates, based on TravelProgress. Null when
    /// not currently traveling, or (only for a character with no known Birthplace who has never
    /// traveled before) when Position itself is still unknown.
    /// </summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public WorldPosition? CurrentTravelPosition
    {
        get
        {
            if (TravelDestination is not { } destination || Position is not { } origin)
            {
                return null;
            }

            var target = CityCoordinates.GetPosition(destination);
            var t = TravelProgress;
            return new WorldPosition(origin.X + (t * (target.X - origin.X)), origin.Y + (t * (target.Y - origin.Y)));
        }
    }

    /// <summary>Cities the current journey's straight-line route passes near, in the order they're reached - see TravelCalculator.FindWaypointCities. Empty when not traveling or Position is unknown.</summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public IReadOnlyList<TravelWaypoint> TravelWaypoints
    {
        get
        {
            if (TravelDestination is not { } destination || Position is not { } origin)
            {
                return [];
            }

            return TravelCalculator.FindWaypointCities(origin, CityCoordinates.GetPosition(destination));
        }
    }

    /// <summary>
    /// Finishes an in-progress journey once enough real time has passed (TravelProgress reaches 1):
    /// moves CurrentLocation and Position to the destination and clears the travel state. Called
    /// whenever a character is loaded (see CharacterViewModel.Character setter), so arrival is picked
    /// up the next time the app or character page is opened - there's no background timer for it.
    /// </summary>
    public void CompleteTravelIfArrived()
    {
        if (TravelDestination is not { } destination || TravelProgress < 1)
        {
            return;
        }

        CurrentLocation = destination;
        Position = CityCoordinates.GetPosition(destination);
        TravelDestination = null;
        TravelDepartureUtc = null;
        TravelDurationDays = 0;
    }

    /// <summary>
    /// Cancels an in-progress journey early (see CharacterViewModel.StopTravelAsync) - the character
    /// is somewhere on the road, not fully at either end, so CurrentLocation becomes City.Unknown
    /// rather than snapping back to where they left from or forward to where they were headed. Position
    /// is set to exactly where they stopped (CurrentTravelPosition, captured before the travel state
    /// clears) so the next Travel starts from their real spot on the road, not a guessed city.
    /// </summary>
    public void StopTraveling()
    {
        if (!IsTraveling)
        {
            return;
        }

        if (CurrentTravelPosition is { } stoppedAt)
        {
            Position = stoppedAt;
        }

        CurrentLocation = City.Unknown;
        TravelDestination = null;
        TravelDepartureUtc = null;
        TravelDurationDays = 0;
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
