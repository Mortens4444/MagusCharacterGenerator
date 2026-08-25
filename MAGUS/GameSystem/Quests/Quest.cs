using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>
/// A quest offered in one specific City - visible while the character is there (see
/// CharacterViewModel.AvailableQuestsHere), accepted, then completed for its reward. Concrete
/// quests are their own class discovered by reflection (PreloadService.LoadQuestsAsync), the same
/// pattern as Qualifications and Spells, so adding an adventure is just adding a new class here.
/// </summary>
public abstract class Quest
{
    public virtual string Key => GetType().Name;

    public abstract string Name { get; }

    public abstract string Description { get; }

    public abstract string Objective { get; }

    public abstract City City { get; }

    public virtual Money MoneyReward => Money.Free;

    public virtual ulong ExperienceReward => 0;

    /// <summary>Suggested character level range for this quest - a guideline shown alongside it, not enforced.</summary>
    public virtual int MinLevel => 1;

    /// <summary>Suggested character level range for this quest - a guideline shown alongside it, not enforced.</summary>
    public virtual int MaxLevel => 3;

    /// <summary>
    /// Bestiary creature class name (e.g. "Wolf") that finishes this quest automatically when killed
    /// in an Encounter - see EncounterViewModel.DieHandler. Null (the default) means the quest has no
    /// combat trigger and can only be finished via the "Mark complete" button (investigation,
    /// negotiation, and other quests a fight can't resolve by itself).
    /// </summary>
    public virtual string? TargetCreatureName => null;

    /// <summary>
    /// True for a combat quest whose opponent has no dedicated Bestiary class (bandits, raiders - a
    /// generic human threat rather than a specific creature type) - see
    /// MAGUS.Assistant.Services.BanditGenerator and EncounterViewModel.CompleteMatchingQuests, which
    /// completes these quests when the killed target is a Character flagged IsGeneratedEnemy instead
    /// of matching TargetCreatureName against a Bestiary type.
    /// </summary>
    public virtual bool TargetIsGeneratedBandit => false;

    /// <summary>
    /// City where a "Search" action can advance this quest (see CharacterViewModel.SearchAsync) -
    /// often the same as City, but not always: a caravan quest offered in Pyarron might actually be
    /// lost along the road from Erigow, so the search happens there instead of where the quest was
    /// picked up. Null (the default) means the quest has no search mechanic.
    /// </summary>
    public virtual City? SearchLocation => null;

    /// <summary>Convenience for XAML bindings, where comparing a nullable enum against null directly isn't available.</summary>
    public bool HasSearchLocation => SearchLocation.HasValue;

    /// <summary>
    /// A d100 roll must come in strictly above this to succeed on a single Search attempt - default
    /// 90 (roughly a 1-in-10 chance per try), so it usually takes several attempts before turning up
    /// whatever was lost. Only meaningful when SearchLocation is set.
    /// </summary>
    public virtual int SearchDifficulty => 90;

    /// <summary>
    /// Percent chance (0-100) that a failed Search attempt turns up trouble instead of just nothing -
    /// see CharacterViewModel.SearchAsync, which rolls this against GameEventService.TriggerRandomEncounterAsync.
    /// Only meaningful when SearchLocation is set. Default 25.
    /// </summary>
    public virtual int SearchDangerChance => 25;

    /// <summary>
    /// Root of a branching negotiation - see DialogueNode/DialogueOption and
    /// CharacterViewModel.NegotiateAsync/DialoguePage (MAGUS.Assistant) for how it's played. Offered
    /// only while the character is in City (unlike Search, negotiation quests don't currently support
    /// a separate location). Null (the default) means the quest has no negotiation mechanic - it can
    /// only be finished via "Mark complete" or whichever other mechanic it declares.
    /// </summary>
    public virtual DialogueNode? DialogueRoot => null;

    /// <summary>Convenience for XAML bindings, where comparing a reference-typed property against null directly isn't available.</summary>
    public bool HasDialogueRoot => DialogueRoot != null;

    /// <summary>
    /// Destination City an escort quest's journey travels to - see CharacterViewModel.TravelAsync,
    /// which rolls EscortDangerChance once when the character departs toward this destination (via
    /// GameEventService.TriggerRandomEncounterAsync), and the CharacterViewModel.Character setter,
    /// which completes the quest once the character actually arrives there alive. Null (the default)
    /// means the quest has no escort mechanic.
    /// </summary>
    public virtual City? EscortDestination => null;

    /// <summary>Convenience for XAML bindings, where comparing a nullable enum against null directly isn't available.</summary>
    public bool HasEscortDestination => EscortDestination.HasValue;

    /// <summary>
    /// Percent chance (0-100) that departing toward EscortDestination triggers an ambush along the
    /// way - rolled once at departure, not per day of travel. Only meaningful when EscortDestination
    /// is set. Default 40 - higher than Search's default danger chance, since deliberately traveling
    /// toward trouble is riskier than searching close to home.
    /// </summary>
    public virtual int EscortDangerChance => 40;

    /// <summary>
    /// City this quest's item must be carried to once found - a "fetch and deliver" quest combines
    /// this with SearchLocation (where the item actually is): a successful Search there moves the
    /// quest to QuestStatus.ItemObtained instead of completing it outright (see
    /// CharacterViewModel.SearchAsync), and it only completes once the character actually arrives at
    /// DeliveryDestination with the item in hand (see CharacterViewModel's travel-arrival hook, the
    /// same mechanism EscortDestination uses for a person instead of an item). Null (the default)
    /// means Search - if this quest has one - still completes the quest directly on success.
    /// </summary>
    public virtual City? DeliveryDestination => null;

    /// <summary>Convenience for XAML bindings, where comparing a nullable enum against null directly isn't available.</summary>
    public bool HasDeliveryDestination => DeliveryDestination.HasValue;

    /// <summary>Short in-fiction name for the item being delivered, used in Search/arrival messages - e.g. "the sealed dispatch". Defaults to the quest's own Name. Only meaningful when DeliveryDestination is set.</summary>
    public virtual string DeliveryItemName => Name;

    /// <summary>
    /// Real hours allowed to complete this quest after accepting it - null (default) means no
    /// deadline. Checked lazily against QuestProgress.AcceptedAtUtc in Character.GetQuestStatus,
    /// the same "catch up whenever queried" pattern as CompleteTravelIfArrived/ApplyElapsedSleepDecay:
    /// once the deadline passes, the quest silently moves to QuestStatus.Failed instead of staying
    /// Accepted forever. Combine with any other mechanic (TargetCreatureName, SearchLocation, ...) to
    /// put a clock on it.
    /// </summary>
    public virtual double? TimeLimitHours => null;

    /// <summary>Convenience for XAML bindings, where comparing a nullable value against null directly isn't available.</summary>
    public bool HasTimeLimit => TimeLimitHours.HasValue;

    /// <summary>
    /// True for a quest completed by keeping a specific NPC ally alive through an Encounter (see
    /// EncounterViewModel.AddProtectedAllyCommand) rather than defeating something - the ally is a
    /// randomly-generated Character fighting alongside the player (same recipe as
    /// MAGUS.Assistant.Services.BanditGenerator, just on the player's side instead of against them).
    /// Completes the moment the Encounter ends with the ally still alive; fails outright - via
    /// Character.FailQuest - the moment the ally dies, regardless of how the rest of the fight goes.
    /// </summary>
    public virtual bool HasProtectAlly => false;

    /// <summary>Short in-fiction name/role for the ally being protected, e.g. "the wounded scout" - shown in the Encounter ally picker. Only meaningful when HasProtectAlly is true.</summary>
    public virtual string AllyDescription => "an ally";

    /// <summary>
    /// True for a quest completed by treating an injured NPC - see CharacterViewModel.HealAsync,
    /// gated on Character.CanHeal (the Healing qualification or a known IHealingSpell). Unlike Search,
    /// there's no roll: having the ability to help IS the resolution, so the "Treat" action just
    /// completes the quest outright once it's available. Offered at City like a normal quest.
    /// </summary>
    public virtual bool RequiresHealing => false;

    /// <summary>
    /// City where a "Steal" action can advance this quest (see CharacterViewModel.StealAsync) - a
    /// theft-flavored sibling of SearchLocation, no qualification required. Null (the default) means
    /// the quest has no steal mechanic.
    /// </summary>
    public virtual City? StealLocation => null;

    /// <summary>Convenience for XAML bindings, where comparing a nullable enum against null directly isn't available.</summary>
    public bool HasStealLocation => StealLocation.HasValue;

    /// <summary>A d100 roll must come in strictly above this to succeed on a single Steal attempt. Only meaningful when StealLocation is set. Default 90, same rarity as Search.</summary>
    public virtual int StealDifficulty => 90;

    /// <summary>
    /// Percent chance (0-100) that a failed Steal attempt gets the character caught instead of just
    /// missing - higher than Search's default danger, since being caught mid-theft is a much more
    /// immediate risk than failing to spot something. Only meaningful when StealLocation is set.
    /// Default 40.
    /// </summary>
    public virtual int StealDangerChance => 40;

    /// <summary>
    /// City where a "Search for traps/secret doors" action can advance this quest (see
    /// CharacterViewModel.SearchForTrapsAsync) - gated on Character.TrapSearchSkillPercent being
    /// above 0 (the TrapDetection/SecretDoorSearch percent qualifications), and rolled against that
    /// character-specific percent instead of a flat difficulty like Search uses. Null (the default)
    /// means the quest has no trap-search mechanic.
    /// </summary>
    public virtual City? TrapLocation => null;

    /// <summary>Convenience for XAML bindings, where comparing a nullable enum against null directly isn't available.</summary>
    public bool HasTrapLocation => TrapLocation.HasValue;

    /// <summary>
    /// Percent chance (0-100) that a failed trap/secret-door search attempt springs the trap instead
    /// of just missing - deals direct damage rather than triggering a random encounter, since a trap
    /// going off isn't an ambush. Only meaningful when TrapLocation is set. Default 35.
    /// </summary>
    public virtual int TrapDangerChance => 35;
}
