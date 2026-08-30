using MAGUS.Assistant.Extensions;
using MAGUS.GameSystem;
using MAGUS.Things;
using MAGUS.Things.Accomodation;
using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Services;

/// <summary>
/// Sleep/Eat/Use-item logic shared by the character list's swipe-row icons (CharactersViewModel) and
/// the CharDetails "care" tab (CharacterViewModel), so both stay in sync with a single implementation.
/// None of these are gated on IsConscious - all are meant to work on an unconscious character too
/// (e.g. feeding someone who fainted from hunger); UseHealingItemAsync additionally works on a dead one.
/// </summary>
internal static class CharacterCareActions
{
    /// <summary>How risky sleeping in the open is compared to a paid room - percent chance (0-100) that it triggers an ambush, rolled once when the character settles in for the night.</summary>
    private const int SleepInTheOpenDangerChance = 30;

    /// <summary>
    /// Starts a wall-clock sleep (see Character.IsSleeping/SleepStartUtc/SleepDurationHours) rather
    /// than resolving instantly: first asks where to sleep - free but risky in the open (rolls
    /// SleepInTheOpenDangerChance for an ambush via GameEventService.TriggerRandomEncounterAsync,
    /// same as Search/Escort danger), or a paid room from MAGUS.Things.Accomodation, deducted from
    /// Money - then how many hours. The actual HP/PRP/Mana/Psi restoration happens later, once that
    /// much real time has passed (see CharacterViewModel.CompleteSleep, called from the Character
    /// setter's lazy "catch up" hook the same way travel arrival is).
    /// </summary>
    public static async Task SleepAsync(Character character, CharacterService characterService, GameEventService gameEventService)
    {
        var rooms = new List<Thing?> { null, new RoomSharedBedroom(), new RoomWithSeparateBed(), new SingleRoom(), new RoomOrnate(), new RoomSuite() };
        var openLabel = Lng.Elem("In the open (free, risk of ambush)");
        var labels = rooms.Select(room => room == null
            ? openLabel
            : $"{Lng.Elem(room.Name)} ({room.Price.ToTranslatedString()})").ToArray();

        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Sleep",
            "Cancel",
            null,
            labels).ConfigureAwait(true);

        var choiceIndex = Array.IndexOf(labels, choice);
        if (choiceIndex < 0)
        {
            return;
        }

        var room = rooms[choiceIndex];
        if (room != null && character.Money < room.Price)
        {
            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Sleep"),
                String.Format(Lng.Elem("{0} cannot afford a {1}."), character.Name, Lng.Elem(room.Name)),
                Lng.Elem("OK")).ConfigureAwait(true);
            return;
        }

        var hoursText = await ShellNavigationService.DisplayPromptAsync(
            "Sleep",
            String.Format(Lng.Elem("How many hours should {0} sleep?"), character.Name),
            "OK",
            "Cancel",
            "8").ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(hoursText) ||
            !Double.TryParse(hoursText, NumberStyles.Float, CultureInfo.InvariantCulture, out var hours) ||
            hours <= 0)
        {
            return;
        }

        if (room != null)
        {
            character.Money -= room.Price;
        }

        character.ApplyElapsedSleepDecay();
        character.SleepStartUtc = DateTime.UtcNow;
        character.SleepDurationHours = hours;

        await characterService.SaveAsync(character).ConfigureAwait(false);

        await ShellNavigationService.DisplayAlertAsync(
            "Sleep",
            String.Format(Lng.Elem("{0} settles in for about {1:F1} hours."), character.Name, hours)).ConfigureAwait(true);

        if (room == null)
        {
            var dangerRoll = new DiceThrow()._1D100();
            if (dangerRoll <= SleepInTheOpenDangerChance)
            {
                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Sleep"),
                    String.Format(Lng.Elem("Something finds {0} sleeping out in the open."), character.Name)).ConfigureAwait(true);

                await gameEventService.TriggerRandomEncounterAsync(character).ConfigureAwait(true);
            }
        }
    }

    public static async Task EatAsync(Character character, CharacterService characterService)
    {
        var foodItems = character.Equipment.Where(item => item.IsFood()).ToList();
        if (foodItems.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(
                "Eat",
                String.Format(Lng.Elem("{0} has no food to eat."), character.Name)).ConfigureAwait(true);
            return;
        }

        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Eat",
            "Cancel",
            null,
            [.. foodItems.Select(item => item.Name)]).ConfigureAwait(true);

        // DisplayActionSheetAsync translates each button label via Lng.Elem() before returning the
        // tapped choice, so comparing against the raw item.Name only matches by luck, whenever the
        // current language happens to have no translation entry for it - e.g. a Hungarian translation
        // for a common food name like "Bread" made this silently fail to match, so Eat did nothing.
        var foodItem = foodItems.FirstOrDefault(item => Lng.Elem(item.Name) == choice);
        if (foodItem == null)
        {
            return;
        }

        // Bulk items (a dozen eggs, a kilo of butter, a jar of honey, ...) are eaten one portion at a
        // time rather than all at once - see Thing.PortionCount/RemainingPortions - so only the last
        // portion actually removes the item from Equipment.
        var portionHungerValue = foodItem.HungerValue / foodItem.PortionCount;
        character.ApplyElapsedHungerDecay();
        character.HungerPercent = Math.Min(100, character.HungerPercent + portionHungerValue);

        foodItem.RemainingPortions--;
        var isFullyConsumed = foodItem.RemainingPortions <= 0;
        if (isFullyConsumed)
        {
            character.RemoveEquipment(foodItem);
        }
        else
        {
            character.NotifyEquipmentWeightChanged();
        }

        await characterService.SaveAsync(character).ConfigureAwait(false);

        var message = isFullyConsumed
            ? String.Format(Lng.Elem("{0} eats the last of the {1} and feels much better."), character.Name, Lng.Elem(foodItem.Name))
            : String.Format(Lng.Elem("{0} eats a portion of the {1} and feels a little better ({2} portion(s) left)."), character.Name, Lng.Elem(foodItem.Name), foodItem.RemainingPortions);

        await ShellNavigationService.DisplayAlertAsync("Eat", message).ConfigureAwait(true);
    }

    /// <summary>
    /// Lets character use one of their own Thing.HealsFully/Resurrects items (e.g. Water of Life) on
    /// any saved character, themselves included - the only place in the app one character's inventory
    /// affects a different character. A dead target can only be picked back up by an item with
    /// Resurrects; a plain full-heal item just declines instead of quietly doing nothing. See
    /// Character.Revive for what "used" actually restores.
    /// </summary>
    public static async Task UseHealingItemAsync(Character character, CharacterService characterService)
    {
        var healingItems = character.Equipment.Where(item => item.IsHealingItem()).ToList();
        if (healingItems.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(
                "Use item",
                String.Format(Lng.Elem("{0} has no healing item to use."), character.Name)).ConfigureAwait(true);
            return;
        }

        var itemChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Use item",
            "Cancel",
            null,
            [.. healingItems.Select(item => item.Name)]).ConfigureAwait(true);

        // See the matching comment in EatAsync - DisplayActionSheetAsync translates each label before
        // returning the tapped choice, so it must be matched back the same way.
        var item = healingItems.FirstOrDefault(i => Lng.Elem(i.Name) == itemChoice);
        if (item == null)
        {
            return;
        }

        // character itself is a live bound instance; every other option is loaded fresh from storage
        // (same "independent instances" approach as EncounterViewModel.LoadBestiaryAsync and
        // CharacterViewModel.CastAsync) so picking someone else doesn't touch whatever unsaved state
        // their own open page might have. Unlike CastAsync's target picker, dead characters are kept
        // in the list - reviving one is the whole point of an item with Resurrects.
        var otherCharacters = (await characterService.GetAllAsync().ConfigureAwait(true))
            .Where(c => c.Id != character.Id)
            .ToList();

        var selfLabel = String.Format(Lng.Elem("Self ({0})"), character.Name);
        var targetNames = new List<string> { selfLabel };
        targetNames.AddRange(otherCharacters.Select(c => c.Name));

        var targetChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Use on",
            "Cancel",
            null,
            [.. targetNames]).ConfigureAwait(true);

        var target = targetChoice == selfLabel ? character : otherCharacters.FirstOrDefault(c => Lng.Elem(c.Name) == targetChoice);
        if (target == null)
        {
            return;
        }

        var wasDead = target.IsDead;
        if (wasDead && !item.Resurrects)
        {
            await ShellNavigationService.DisplayAlertAsync(
                "Use item",
                String.Format(Lng.Elem("{0} is dead - the {1} can't bring them back."), target.Name, Lng.Elem(item.Name))).ConfigureAwait(true);
            return;
        }

        target.Revive();

        item.RemainingPortions--;
        var isFullyConsumed = item.RemainingPortions <= 0;
        if (isFullyConsumed)
        {
            character.RemoveEquipment(item);
        }
        else
        {
            character.NotifyEquipmentWeightChanged();
        }

        await characterService.SaveAsync(character).ConfigureAwait(false);
        if (target.Id != character.Id)
        {
            await characterService.SaveAsync(target).ConfigureAwait(false);
        }

        var message = wasDead
            ? String.Format(Lng.Elem("{0} uses the {1} on {2} - {2} draws breath again, every wound closed."), character.Name, Lng.Elem(item.Name), target.Name)
            : String.Format(Lng.Elem("{0} uses the {1} on {2} - every wound closes."), character.Name, Lng.Elem(item.Name), target.Name);

        await ShellNavigationService.DisplayAlertAsync("Use item", message).ConfigureAwait(true);
    }
}
