using MAGUS.GameSystem;
using MAGUS.GameSystem.Places;
using MAGUS.Things.Animals;
using MAGUS.Things.MagicalObjects;
using Mtf.LanguageService;

namespace MAGUS.Assistant.Services;

/// <summary>
/// Lets two characters standing in the same city (Character.IsAtSameLocationAs) form a shared travel
/// group (Character.GroupMemberNames), and keeps a group moving together: once grouped, changing one
/// member's destination via CharacterViewModel.TravelAsync carries every other member along too (see
/// SetGroupTravelAsync), each at their own race/mount-appropriate speed.
/// </summary>
internal static class CharacterGroupActions
{
    /// <summary>
    /// Offers every other saved, living character standing in the same city as character (and not
    /// already grouped with it) as someone to join up with. Joining merges both characters' existing
    /// groups (if any) into one, so everyone already grouped with either of them ends up knowing about
    /// everyone else - not just the two who tapped Join.
    /// </summary>
    public static async Task JoinGroupAsync(Character character, CharacterService characterService)
    {
        var all = await characterService.GetAllAsync().ConfigureAwait(true);
        var candidates = all
            .Where(c => c.Name != character.Name && !c.IsDead && !character.GroupMemberNames.Contains(c.Name) && character.IsAtSameLocationAs(c))
            .ToList();

        if (candidates.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(
                "Group",
                String.Format(Lng.Elem("No other character is here for {0} to group with."), character.Name)).ConfigureAwait(true);
            return;
        }

        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Join group",
            "Cancel",
            null,
            [.. candidates.Select(c => c.Name)]).ConfigureAwait(true);

        // DisplayActionSheetAsync translates each button label via Lng.Elem() before returning the
        // tapped choice, so comparing against the raw Name only matches by luck, whenever the current
        // language happens to have no translation entry for it (unlikely for a player-chosen name, but
        // matches the safe pattern used everywhere else a picked name is matched back).
        var chosen = candidates.FirstOrDefault(c => Lng.Elem(c.Name) == choice);
        if (chosen == null)
        {
            return;
        }

        // Merge: everyone already grouped with either character or chosen, plus the two of them
        // themselves, ends up in one shared group knowing about everyone else in it.
        var memberNames = new HashSet<string>(character.GroupMemberNames) { character.Name, chosen.Name };
        memberNames.UnionWith(chosen.GroupMemberNames);

        var members = new List<Character> { character, chosen };
        foreach (var name in memberNames)
        {
            if (name == character.Name || name == chosen.Name)
            {
                continue;
            }

            var member = await characterService.GetByNameAsync(name).ConfigureAwait(true);
            if (member != null)
            {
                members.Add(member);
            }
        }

        foreach (var member in members)
        {
            member.GroupMemberNames = [.. memberNames.Where(n => n != member.Name)];
            await characterService.SaveAsync(member).ConfigureAwait(false);
        }

        await ShellNavigationService.DisplayAlertAsync(
            "Group",
            String.Format(Lng.Elem("{0} and {1} are now traveling together."), character.Name, chosen.Name)).ConfigureAwait(true);
    }

    /// <summary>Removes character from its group - every remaining member forgets it, and it forgets every one of them.</summary>
    public static async Task LeaveGroupAsync(Character character, CharacterService characterService)
    {
        if (!character.IsInGroup)
        {
            return;
        }

        var confirm = await ShellNavigationService.DisplayAlertAsync(
            "Group",
            String.Format(Lng.Elem("{0} leaves the group. Continue?"), character.Name),
            Lng.Elem("Leave"),
            Lng.Elem("Cancel")).ConfigureAwait(true);

        if (!confirm)
        {
            return;
        }

        foreach (var name in character.GroupMemberNames)
        {
            var member = await characterService.GetByNameAsync(name).ConfigureAwait(true);
            if (member != null)
            {
                member.GroupMemberNames = [.. member.GroupMemberNames.Where(n => n != character.Name)];
                await characterService.SaveAsync(member).ConfigureAwait(false);
            }
        }

        character.GroupMemberNames = [];
        await characterService.SaveAsync(character).ConfigureAwait(false);
    }

    /// <summary>
    /// Carries every other member of leader's group along on the same journey leader just started -
    /// same destination and departure instant, but each member computes their own TravelDurationDays
    /// (TravelCalculator.CalculateDays already varies Walking speed by race) and falls back to Walking
    /// for a mode a given member can't actually use (no Horse for Horseback, no FlyingCarpet for
    /// Flying) rather than blocking the whole group's departure over one member's missing gear. A
    /// member who can't afford a Ship fare falls back the same way.
    /// </summary>
    public static async Task SetGroupTravelAsync(
        Character leader,
        City destination,
        WorldPosition destinationPosition,
        TransportMode mode,
        DateTime departureUtc,
        CharacterService characterService)
    {
        foreach (var name in leader.GroupMemberNames)
        {
            var member = await characterService.GetByNameAsync(name).ConfigureAwait(true);
            if (member == null || member.IsDead)
            {
                continue;
            }

            var origin = member.Position ?? (member.Birthplace != City.Unknown ? CityCoordinates.GetPosition(member.Birthplace) : (WorldPosition?)null);
            if (origin is null)
            {
                continue;
            }

            var memberMode = mode switch
            {
                TransportMode.Horseback when !member.HasItem<Horse>() => TransportMode.Walking,
                TransportMode.Flying when !member.HasItem<FlyingCarpet>() => TransportMode.Walking,
                TransportMode.Ship when member.Money < TravelCalculator.CalculateShipFare(origin.Value, destinationPosition) => TransportMode.Walking,
                _ => mode
            };

            if (memberMode == TransportMode.Ship)
            {
                member.Money -= TravelCalculator.CalculateShipFare(origin.Value, destinationPosition);
            }

            member.Position ??= origin;
            member.TravelDestination = destination;
            member.TravelDepartureUtc = departureUtc;
            member.TravelDurationDays = TravelCalculator.CalculateDays(origin.Value, destinationPosition, memberMode, member);

            await characterService.SaveAsync(member).ConfigureAwait(false);
        }
    }
}
