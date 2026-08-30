using MAGUS.GameSystem.Places;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// Names of the other characters currently traveling together with this one as a group - kept
    /// fully mutual (every member's list names every other member) by CharacterGroupActions, the only
    /// place this is mutated. When a grouped character's destination changes via
    /// CharacterViewModel.TravelAsync, every named member gets the same TravelDestination and
    /// TravelDepartureUtc, each computing their own TravelDurationDays for their own race/mount.
    /// </summary>
    public List<string> GroupMemberNames { get; set; } = [];

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool IsInGroup => GroupMemberNames.Count > 0;

    /// <summary>True when this and other are both stationary (not traveling) in the same known city - the precondition for joining a group together (see CharacterGroupActions.JoinGroupAsync).</summary>
    public bool IsAtSameLocationAs(Character other)
    {
        return other != null && !IsTraveling && !other.IsTraveling && CurrentLocation != City.Unknown && CurrentLocation == other.CurrentLocation;
    }
}
