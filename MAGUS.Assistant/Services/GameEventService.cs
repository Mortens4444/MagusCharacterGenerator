using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Enums;
using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.ViewModels;
using MAGUS.Assistant.Views;
using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem;
using MAGUS.Things;
using MAGUS.Things.Animals;
using Mtf.Extensions.Services;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Services;

internal sealed class GameEventService(CharacterService characterService, IServiceProvider serviceProvider)
{
    private static readonly string[] flavorOnlyMessages = [
        "You heard a strange noise. In the Battle menu, you can find out what it was...",
        "You can send your opinion about the game, or what should be improved, to the email address found in the About menu.",
        "If the gods of luck are on your side today, you will soon find out in the Dice menu.",
        "You found the tracks of an unknown creature in the mud. In the Bestiary menu, you can look up what you are facing.",
        "- Stupid dog, what are you snarling at! (Last words)",
        "- Relax, it is just a kobold. How dangerous can it be? (Last words)",
        "- I think it is asleep. I will go over and poke it. (Last words)",
        "- Let us not waste magic on it. I will handle it with a stick. (Last words)",
        "- What trap? I do not see any trap. (Last words)",
        "- I bet this drink is a healing potion. (Last words)",
        "- The necromancer is a person too. Let us talk it out with him. (Last words)",
        "- Come on, statues do not move. (Last words)",
        "- Do not worry, I can swim in armor. (Last words)",
        "- This bridge looks completely stable. (Last words)",
        "- Who is Darton, and why should I be afraid of him? (Last words)",
        "- We do not need a watch. No one comes through here anyway. (Last words)",
        "- I will distract the giant. (Last words)",
        "- According to the map, this way is shorter. (Last words)",
        "- The sound came from inside the wall. I will put my ear to it. (Last words)",
        "- This wolf is too skinny to be a problem. (Last words)",
        "- The orc is just bluffing. (Last words)",
        "- Relax, I know what I am doing. (Last words)",
        "- If you are going to be picky, I will eat it! (Last words)"
    ];

    private static readonly string[] personInNeedTraits = ["young", "small", "strong", "big", "sick", "old", "tired", "wounded"];
    private static readonly string[] personInNeedGenderWords = ["man", "woman", "boy", "girl"];

    // Weights read as percent chance (sum to 100) purely for readability - PickWeightedRandom
    // only cares about the ratios between them, so this isn't a functional requirement, just
    // keep it true when adding/removing an event so the numbers stay meaningful at a glance.
    private static readonly (GameEventKind Kind, int Weight)[] eventWeights = [
        (GameEventKind.Flavor, 41),
        (GameEventKind.MarketSale, 7),
        (GameEventKind.MarketInflation, 4),
        (GameEventKind.ItemStolen, 5),
        (GameEventKind.Ambush, 11),
        (GameEventKind.FortuneGift, 7),
        (GameEventKind.StrayDog, 5),
        (GameEventKind.PersonInNeed, 8),
        (GameEventKind.Trap, 5)
    ];

    // Hunger and sleep no longer compete for a slot in eventWeights above - both decay
    // unconditionally every tick (see ApplyHungerTickAsync/ApplySleepTickAsync), independent of
    // which random event (if any) also rolls.
    private const double HungerDecayPercentPerTick = 100.0 / 8; // 0% (fully starving) after 8 ticks without food
    private const double SleepDecayPercentPerTick = 100.0 / 16; // 0% (exhausted) after 16 ticks without sleep - a character needs to sleep about half as often as they need to eat
    private const double CriticalNeedThreshold = 10; // shared by hunger and sleep: below this, each further tick costs Fájdalomtűrés/HP

    // Non-critical "you should eat/sleep soon" warnings, shown once each as the percentage first
    // drops below them (lowest/most urgent one crossed in a given tick wins, in case a single
    // tick's decay skips past more than one - e.g. the fixed-size hunger step from 25% lands on
    // 12.5%, crossing both 20 and 15 at once). Kept ascending so the ordering logic below reads
    // naturally. Shared between hunger and sleep since both use the same warning percentages.
    private static readonly double[] needWarningThresholds = [20, 15];

    private readonly DiceThrow diceThrow = new();
    private readonly CharacterService characterService = characterService;
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public static string PickFlavorOnlyMessage()
    {
        var index = RandomProvider.GetSecureRandomInt(0, flavorOnlyMessages.Length);
        return flavorOnlyMessages[index];
    }

    // GameEventService is a singleton but SettingsService is transient and caches its values
    // in memory at construction time, so a SettingsService captured once (e.g. via constructor
    // injection) would never see settings changed afterwards (default character, pending event,
    // ...) by any other part of the app. Resolving a fresh instance per call keeps it current.
    private SettingsService GetCurrentSettings() => serviceProvider.GetRequiredService<SettingsService>();

    public bool HasPendingInteractiveEvent => !String.IsNullOrEmpty(GetCurrentSettings().PendingEventKind);

    /// <summary>
    /// Rolls a random story event and, when a default character is set, applies its real effect
    /// (market prices, a stolen item, or a pending ambush) against that character. Hunger and sleep
    /// both decay unconditionally on every tick regardless of what else rolls (see
    /// ApplyHungerTickAsync/ApplySleepTickAsync) - both always run, so neither's progress is ever
    /// skipped because the other also had something to say this tick. Only when one of them actually
    /// has something noteworthy (a threshold crossed, or critical damage) does it dominate the tick
    /// and suppress the normal roll; hunger wins if both do in the same tick, an arbitrary but
    /// deterministic tie-break for what should be a rare simultaneous crossing.
    /// </summary>
    public async Task<(string Title, string Message)> RollAndApplyAsync()
    {
        try
        {
            var settingsService = GetCurrentSettings();
            var character = await GetDefaultCharacterAsync(settingsService).ConfigureAwait(false);

            if (character is not null)
            {
                var hungerResult = await ApplyHungerTickAsync(character).ConfigureAwait(false);
                var sleepResult = await ApplySleepTickAsync(character).ConfigureAwait(false);

                if (hungerResult is { } hunger)
                {
                    return hunger;
                }

                if (sleepResult is { } sleep)
                {
                    return sleep;
                }
            }

            var kind = character is null ? GameEventKind.Flavor : PickEventKind();

            return kind switch
            {
                GameEventKind.MarketSale => await ApplyMarketEventAsync(settingsService, 0.5,
                    "A traveling merchant is desperate to offload his stock - everything in the Market is half price for a while!").ConfigureAwait(false),
                GameEventKind.MarketInflation => await ApplyMarketEventAsync(settingsService, 2.0,
                    "Word is a noble's caravan is buying up supplies - Market prices have doubled for a while.").ConfigureAwait(false),
                GameEventKind.ItemStolen => await ApplyItemStolenAsync(character!).ConfigureAwait(false),
                GameEventKind.Ambush => await ApplyAmbushAsync(settingsService, character!).ConfigureAwait(false),
                GameEventKind.FortuneGift => await ApplyFortuneGiftAsync(character!).ConfigureAwait(false),
                GameEventKind.StrayDog => await ApplyStrayDogAsync(character!).ConfigureAwait(false),
                GameEventKind.PersonInNeed => await ApplyPersonInNeedAsync(settingsService, character!).ConfigureAwait(false),
                GameEventKind.Trap => await ApplyTrapAsync(character!).ConfigureAwait(false),
                _ => ("MAGUS Assistant", Lng.Elem(PickFlavorOnlyMessage())),
            };
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            return ("MAGUS Assistant", Lng.Elem(PickFlavorOnlyMessage()));
        }
    }

    /// <summary>
    /// Called whenever the app becomes active (see MainActivity.OnResume). If a background event
    /// left something waiting for a live decision (an ambush, a stranger in need, ...), this shows
    /// the relevant prompt and applies whatever follows from the player's choice.
    /// </summary>
    public async Task ResolvePendingInteractiveEventIfAnyAsync()
    {
        var settingsService = GetCurrentSettings();
        var kind = settingsService.PendingEventKind;
        if (String.IsNullOrEmpty(kind))
        {
            return;
        }

        var payload = settingsService.PendingEventPayload;
        await settingsService.SavePendingEventAsync(null, null).ConfigureAwait(true);

        try
        {
            if (kind == nameof(GameEventKind.Ambush) && !String.IsNullOrEmpty(payload))
            {
                await ResolveAmbushAsync(settingsService, payload).ConfigureAwait(true);
            }
            else if (kind == nameof(GameEventKind.PersonInNeed))
            {
                await ResolvePersonInNeedAsync(settingsService, payload).ConfigureAwait(true);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async Task ResolveAmbushAsync(SettingsService settingsService, string creatureTypeName)
    {
        await PreloadService.Instance.InitializeAsync().ConfigureAwait(true);

        var creature = PreloadService.Instance.Creatures.FirstOrDefault(c => c.GetType().Name == creatureTypeName);
        var character = await GetDefaultCharacterAsync(settingsService).ConfigureAwait(true);

        if (creature is null || character is null)
        {
            return;
        }

        var creatureName = Lng.Elem(creature.Name);
        var message = String.Format(Lng.Elem("A {0} blocks your path, {1}. Flee, or stand and fight?"), creatureName, character.Name);

        var ambushPage = new AmbushPage(creature, character.Name, message);
        await ShellNavigationService.ShowModalPageAsync(ambushPage).ConfigureAwait(true);
        var fight = await ambushPage.ResultTask.ConfigureAwait(true);

        if (!fight)
        {
            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Narrow escape"),
                String.Format(Lng.Elem("You slip away into the night, leaving the {0} behind."), creatureName)).ConfigureAwait(true);
            return;
        }

        var encounterViewModel = serviceProvider.GetRequiredService<EncounterViewModel>();
        await encounterViewModel.LoadCharactersAsync().ConfigureAwait(true);
        await encounterViewModel.LoadBestiaryAsync().ConfigureAwait(true);
        encounterViewModel.StartAmbush(character, creature);

        var encounterPage = new EncounterPage(encounterViewModel)
        {
            SuppressAutoInitialize = true
        };
        await ShellNavigationService.ShowPageAsync(encounterPage).ConfigureAwait(true);
    }

    private async Task ResolvePersonInNeedAsync(SettingsService settingsService, string? payload)
    {
        var character = await GetDefaultCharacterAsync(settingsService).ConfigureAwait(true);
        if (character is null)
        {
            return;
        }

        var parts = payload?.Split('|') ?? [];
        var trait = parts.Length > 0 ? parts[0] : personInNeedTraits[0];
        var genderWord = parts.Length > 1 ? parts[1] : personInNeedGenderWords[0];
        var raceName = parts.Length > 2 ? parts[2] : "traveler";
        var description = DescribePersonInNeed(trait, genderWord, raceName);

        var help = await ShellNavigationService.DisplayAlertAsync(
            Lng.Elem("A stranger in need"),
            String.Format(Lng.Elem("You come across {0} in distress on the road, {1}. Do you help them, or take advantage of them?"), description, character.Name),
            Lng.Elem("Help"),
            Lng.Elem("Attack")).ConfigureAwait(true);

        // Hunger is the one trait with a real cost: helping only works if there is food to give.
        Thing? givenFood = null;
        if (help && trait == "hungry")
        {
            givenFood = character.Equipment.FirstOrDefault(t => t.IsFood());
            if (givenFood is not null)
            {
                character.RemoveEquipment(givenFood);
            }
        }

        // Order/Life-leaning characters are rewarded for helping; Chaos/Death-leaning characters
        // are rewarded for the opposite. Genuinely mixed alignments (e.g. ChaosLife, OrderDeath)
        // don't lean either way, so neither choice earns a bonus for them.
        var isOrderLifeAligned = character.Alignment is Alignment.Life or Alignment.Order or Alignment.LifeOrder or Alignment.OrderLife;
        var isChaosDeathAligned = character.Alignment is Alignment.Chaos or Alignment.Death or Alignment.ChaosDeath or Alignment.DeathChaos;
        var earnsXp = (help && isOrderLifeAligned) || (!help && isChaosDeathAligned);

        string message;
        if (earnsXp)
        {
            const ulong RewardXp = 50;
            character.BaseClass!.ExperiencePoints += RewardXp;

            message = help
                ? givenFood is not null
                    ? String.Format(Lng.Elem("You share your {2} with them, {0}. Your kindness earns you {1} XP."), character.Name, RewardXp, Lng.Elem(givenFood.Name))
                    : String.Format(Lng.Elem("Your kindness is who you are, {0} - and it earns you {1} XP."), character.Name, RewardXp)
                : String.Format(Lng.Elem("You take what you can and leave, {0}. Your ruthlessness earns you {1} XP."), character.Name, RewardXp);
        }
        else
        {
            message = help
                ? givenFood is not null
                    ? String.Format(Lng.Elem("You share your {1} with them, {0}. They thank you and go on their way."), character.Name, Lng.Elem(givenFood.Name))
                    : String.Format(Lng.Elem("You help the stranger, {0}. They thank you and go on their way."), character.Name)
                : String.Format(Lng.Elem("You leave the stranger to their fate, {0}, and continue on your journey."), character.Name);
        }

        await characterService.SaveAsync(character).ConfigureAwait(true);
        await ShellNavigationService.DisplayAlertAsync(Lng.Elem("A stranger in need"), message).ConfigureAwait(true);
    }

    private async Task<Character?> GetDefaultCharacterAsync(SettingsService settingsService)
    {
        var name = settingsService.DefaultCharacterName;
        if (String.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        return await characterService.GetByNameAsync(name).ConfigureAwait(false);
    }

    private static GameEventKind PickEventKind() => EnemyProvider.PickWeightedRandom(eventWeights, w => w.Weight).Kind;

    private async Task<(string Title, string Message)> ApplyMarketEventAsync(SettingsService settingsService, double multiplier, string flavorText)
    {
        await PreloadService.Instance.InitializeAsync().ConfigureAwait(false);

        foreach (var thing in PreloadService.Instance.Things)
        {
            thing.PriceMultiplier = multiplier;
        }

        await settingsService.SaveActiveMarketPriceMultiplierAsync(multiplier).ConfigureAwait(false);

        return ("MAGUS Assistant", Lng.Elem(flavorText));
    }

    private async Task<(string Title, string Message)> ApplyItemStolenAsync(Character character)
    {
        if (character.Equipment.Count == 0)
        {
            return ("MAGUS Assistant",
                Lng.Elem("You feel like something's off tonight, but a quick check shows nothing missing. Lucky, this time."));
        }

        var index = RandomProvider.GetSecureRandomInt(0, character.Equipment.Count);
        var stolenItem = character.Equipment[index];
        var itemName = Lng.Elem(stolenItem.Name);

        character.RemoveEquipment(stolenItem);
        await characterService.SaveAsync(character).ConfigureAwait(false);

        return ("MAGUS Assistant",
            String.Format(Lng.Elem("You wake up to find your pouch feels lighter, {0}... your {1} is gone. Stolen, maybe?"), character.Name, itemName));
    }

    private async Task<(string Title, string Message)> ApplyAmbushAsync(SettingsService settingsService, Character character)
    {
        await PreloadService.Instance.InitializeAsync().ConfigureAwait(false);

        var creature = EnemyProvider.PickWeightedRandom(PreloadService.Instance.Creatures, c => c.Occurrence.GetWeight());
        if (creature is null)
        {
            return ("MAGUS Assistant", Lng.Elem(PickFlavorOnlyMessage()));
        }

        await settingsService.SavePendingEventAsync(nameof(GameEventKind.Ambush), creature.GetType().Name).ConfigureAwait(false);

        var creatureName = Lng.Elem(creature.Name);
        return ("MAGUS Assistant",
            String.Format(Lng.Elem("Steel glints in the moonlight - a {0} lunges at {1} from the shadows! Open the app to decide: flee, or fight?"), creatureName, character.Name));
    }

    private async Task<(string Title, string Message)> ApplyFortuneGiftAsync(Character character)
    {
        await PreloadService.Instance.InitializeAsync().ConfigureAwait(false);

        var giveGemstone = RandomProvider.GetSecureRandomInt(0, 2) == 0;
        var pool = giveGemstone
            ? PreloadService.Instance.Gemstones.Cast<Thing>().ToList()
            : PreloadService.Instance.MagicalObjects.Cast<Thing>().ToList();

        if (pool.Count == 0)
        {
            return ("MAGUS Assistant",
                Lng.Elem("Luck seems to be smiling on you today, though nothing comes of it just yet."));
        }

        var index = RandomProvider.GetSecureRandomInt(0, pool.Count);
        var gift = pool[index];
        var itemName = Lng.Elem(gift.Name);

        character.Equipment.Add(gift);
        await characterService.SaveAsync(character).ConfigureAwait(false);

        var message = giveGemstone
            ? String.Format(Lng.Elem("Luck is on your side, {0} - you spot a glint in the dirt and pick up a {1}!"), character.Name, itemName)
            : String.Format(Lng.Elem("A grateful stranger presses a {1} into your hands, {0}, and vanishes into the crowd before you can ask why."), character.Name, itemName);

        return ("MAGUS Assistant", message);
    }

    private async Task<(string Title, string Message)> ApplyStrayDogAsync(Character character)
    {
        Thing[] pool = [new DogGuard(), new DogHunting()];
        var index = RandomProvider.GetSecureRandomInt(0, pool.Length);
        var dog = pool[index];
        var dogName = Lng.Elem(dog.Name);

        character.Equipment.Add(dog);
        await characterService.SaveAsync(character).ConfigureAwait(false);

        return ("MAGUS Assistant",
            String.Format(Lng.Elem("A stray {0} has taken a liking to you, {1}, and now follows you everywhere."), dogName, character.Name));
    }

    private async Task<(string Title, string Message)> ApplyPersonInNeedAsync(SettingsService settingsService, Character character)
    {
        await PreloadService.Instance.InitializeAsync().ConfigureAwait(false);

        var hasFood = character.Equipment.Any(t => t.IsFood());
        var trait = PickPersonInNeedTrait(hasFood);
        var genderWord = personInNeedGenderWords[RandomProvider.GetSecureRandomInt(0, personInNeedGenderWords.Length)];
        var races = PreloadService.Instance.Races;
        var raceName = races.Count > 0 ? races[RandomProvider.GetSecureRandomInt(0, races.Count)].Name : "traveler";

        await settingsService.SavePendingEventAsync(nameof(GameEventKind.PersonInNeed), String.Join('|', trait, genderWord, raceName)).ConfigureAwait(false);

        var description = DescribePersonInNeed(trait, genderWord, raceName);
        return ("MAGUS Assistant",
            String.Format(Lng.Elem("You come across {0} on the road, {1}. Open the app to decide how to respond."), description, character.Name));
    }

    private static string PickPersonInNeedTrait(bool hasFood)
    {
        // "Hungry" is only eligible when the character actually has food to give, so the choice
        // to Help can never be a dead end once the trait comes up.
        if (hasFood && RandomProvider.GetSecureRandomInt(0, personInNeedTraits.Length + 1) == personInNeedTraits.Length)
        {
            return "hungry";
        }

        return personInNeedTraits[RandomProvider.GetSecureRandomInt(0, personInNeedTraits.Length)];
    }

    private static string DescribePersonInNeed(string trait, string genderWord, string raceName)
    {
        var article = trait == "old" ? "an" : "a";
        return $"{article} {Lng.Elem(trait)} {Lng.Elem(raceName)} {Lng.Elem(genderWord)}";
    }

    /// <summary>
    /// Runs on every background tick regardless of whether a random event also rolls: hunger always
    /// drains by HungerDecayPercentPerTick. Crossing a needWarningThresholds entry (20%, 15%) shows
    /// a one-time "you should eat soon" nudge with no mechanical effect yet. Below
    /// CriticalNeedThreshold it starts actively hurting the character each further tick - pain
    /// tolerance drains first (down to unconsciousness), and once that's exhausted, health points
    /// start dropping instead, all the way to death if hunger is never addressed. Returns null only
    /// when nothing noteworthy happened this tick, so the caller knows to let the normal event roll
    /// (or the sleep tick's own message) take priority instead.
    /// </summary>
    private async Task<(string Title, string Message)?> ApplyHungerTickAsync(Character character)
    {
        var previousHungerPercent = character.HungerPercent;
        character.HungerPercent = Math.Max(0, previousHungerPercent - HungerDecayPercentPerTick);

        if (character.HungerPercent >= CriticalNeedThreshold)
        {
            await characterService.SaveAsync(character).ConfigureAwait(false);

            var crossedThreshold = needWarningThresholds
                .Where(threshold => previousHungerPercent >= threshold && character.HungerPercent < threshold)
                .OrderBy(threshold => threshold)
                .Cast<double?>()
                .FirstOrDefault();

            if (crossedThreshold is not { } threshold)
            {
                return null;
            }

            var warningMessage = threshold <= 15
                ? String.Format(Lng.Elem("You're quite hungry now, {0} ({1:F0}% fed) - eat soon or it will start to hurt."), character.Name, character.HungerPercent)
                : String.Format(Lng.Elem("Your stomach growls, {0} ({1:F0}% fed) - you're getting hungry."), character.Name, character.HungerPercent);

            return ("MAGUS Assistant", warningMessage);
        }

        var damage = diceThrow._1D6();
        var hasPainTolerance = character.MaxPainTolerancePoints.HasValue;
        var currentPainTolerancePoints = character.ActualPainTolerancePoints ?? 0;

        string message;
        if (hasPainTolerance && currentPainTolerancePoints > 0)
        {
            character.ActualPainTolerancePoints = Math.Max(0, currentPainTolerancePoints - damage);
            message = character.ActualPainTolerancePoints <= 0
                ? String.Format(Lng.Elem("Starvation has worn you down, {0} - you collapse, barely conscious. Eat something!"), character.Name)
                : String.Format(Lng.Elem("You are critically hungry, {0}, and it is starting to hurt badly. Eat something now!"), character.Name);
        }
        else
        {
            character.ActualHealthPoints = Math.Max(0, character.ActualHealthPoints - damage);
            message = character.IsDead
                ? String.Format(Lng.Elem("{0} has starved to death. Without food, the body simply gives out."), character.Name)
                : String.Format(Lng.Elem("Starvation is taking its toll on your body, {0}. You need food, now."), character.Name);
        }

        await characterService.SaveAsync(character).ConfigureAwait(false);

        return ("MAGUS Assistant", message);
    }

    /// <summary>
    /// Sleep's counterpart to ApplyHungerTickAsync - same shape, half the decay rate (a character
    /// needs to sleep about half as often as they need to eat), same shared warning/critical
    /// thresholds. Returns null only when nothing noteworthy happened this tick.
    /// </summary>
    private async Task<(string Title, string Message)?> ApplySleepTickAsync(Character character)
    {
        var previousSleepPercent = character.SleepPercent;
        character.SleepPercent = Math.Max(0, previousSleepPercent - SleepDecayPercentPerTick);

        if (character.SleepPercent >= CriticalNeedThreshold)
        {
            await characterService.SaveAsync(character).ConfigureAwait(false);

            var crossedThreshold = needWarningThresholds
                .Where(threshold => previousSleepPercent >= threshold && character.SleepPercent < threshold)
                .OrderBy(threshold => threshold)
                .Cast<double?>()
                .FirstOrDefault();

            if (crossedThreshold is not { } threshold)
            {
                return null;
            }

            var warningMessage = threshold <= 15
                ? String.Format(Lng.Elem("You're exhausted, {0} ({1:F0}% rested) - sleep soon or it will start to hurt."), character.Name, character.SleepPercent)
                : String.Format(Lng.Elem("You're getting tired, {0} ({1:F0}% rested) - you should sleep soon."), character.Name, character.SleepPercent);

            return ("MAGUS Assistant", warningMessage);
        }

        var damage = diceThrow._1D6();
        var hasPainTolerance = character.MaxPainTolerancePoints.HasValue;
        var currentPainTolerancePoints = character.ActualPainTolerancePoints ?? 0;

        string message;
        if (hasPainTolerance && currentPainTolerancePoints > 0)
        {
            character.ActualPainTolerancePoints = Math.Max(0, currentPainTolerancePoints - damage);
            message = character.ActualPainTolerancePoints <= 0
                ? String.Format(Lng.Elem("Sleep deprivation has worn you down, {0} - you collapse, barely conscious. Get some sleep!"), character.Name)
                : String.Format(Lng.Elem("You are critically sleep-deprived, {0}, and it is starting to hurt badly. Sleep now!"), character.Name);
        }
        else
        {
            character.ActualHealthPoints = Math.Max(0, character.ActualHealthPoints - damage);
            message = character.IsDead
                ? String.Format(Lng.Elem("{0} has collapsed from exhaustion and never woke up again."), character.Name)
                : String.Format(Lng.Elem("Exhaustion is taking its toll on your body, {0}. You need sleep, now."), character.Name);
        }

        await characterService.SaveAsync(character).ConfigureAwait(false);

        return ("MAGUS Assistant", message);
    }

    private async Task<(string Title, string Message)> ApplyTrapAsync(Character character)
    {
        var damage = RandomProvider.GetSecureRandomInt(2, 7);
        character.ActualHealthPoints = Math.Max(0, character.ActualHealthPoints - damage);
        await characterService.SaveAsync(character).ConfigureAwait(false);

        var message = character.IsDead
            ? String.Format(Lng.Elem("{0} didn't see the trap in time. It was fatal."), character.Name)
            : String.Format(Lng.Elem("You trigger a hidden trap, {0}, and take {1} damage!"), character.Name, damage);

        return ("MAGUS Assistant", message);
    }
}
