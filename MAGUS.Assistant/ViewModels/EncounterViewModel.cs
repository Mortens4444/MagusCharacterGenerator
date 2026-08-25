using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Enums;
using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.Views;
using MAGUS.Bestiary;
using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Quests;
using MAGUS.Interfaces;
using MAGUS.Services;
using MAGUS.Things;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;
using Mtf.Extensions;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class EncounterViewModel(ISettings settings, CharacterService characterService, ISoundPlayer soundPlayer, IShakeService shakeService) : CharacterListLoaderViewModel(characterService), IDisposable
{
    private Character? selectedCharacter;
    private Attacker? selectedEnemy;
    private AssignmentViewModel? selectedAssignment;
    private readonly ISettings settings = settings;
    private bool showControls = true;
    private bool isRunningTurns;
    private AssignmentViewModel? previousSelectedAssignment;
    private readonly ISoundPlayer soundPlayer = soundPlayer;
    private readonly IShakeService shakeService = shakeService;

    /// <summary>
    /// A permanent "Bandit" entry mixed into AvailableEnemies (see LoadBestiaryAsync) alongside the
    /// real Bestiary/Character picks - never itself added to a fight. Picking it and pressing "Add
    /// enemy" is instead detected by reference in AddEnemyAsync and generates a fresh, actually-named
    /// BanditGenerator.CreateRandomBandit each time, so the same list entry can be used repeatedly to
    /// spawn a different bandit every time.
    /// </summary>
    private readonly Character banditPlaceholder = new(settings) { Name = "Bandit" };

    /// <summary>Ally Assignments added via AddProtectedAllyAsync, mapped to the protect-quest they're standing in for and the character who accepted it - checked in DieHandler (ally dies -> quest fails) and EndEncounter (ally survives -> quest completes).</summary>
    private readonly Dictionary<AssignmentViewModel, (Quest Quest, Character Protector)> protectedAllies = [];

    public ObservableCollection<TurnViewModel> SelectedTurnHistory { get; } = [];
    public ObservableCollection<Character> Characters { get; } = [];
    public ObservableCollection<Attacker> Enemies { get; } = [];
    public ObservableCollection<Attacker> AvailableEnemies { get; } = [];
    public ObservableCollection<AssignmentViewModel> Assignments { get; } = [];
    
    public ISettings Settings
    {
        get => settings;
    }

    public bool ShowControls
    {
        get => showControls;
        set => SetProperty(ref showControls, value);
    }

    public bool IsRunningTurns
    {
        get => isRunningTurns;
        set
        {
            if (SetProperty(ref isRunningTurns, value))
            {
                RunTurnCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public Character? SelectedCharacter
    {
        get => selectedCharacter;
        set
        {
            if (SetProperty(ref selectedCharacter, value))
            {
                AddCharacterCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public Attacker? SelectedEnemy
    {
        get => selectedEnemy;
        set
        {
            if (SetProperty(ref selectedEnemy, value))
            {
                AddEnemyCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public AssignmentViewModel? SelectedAssignment
    {
        get => selectedAssignment;
        set
        {
            if (SetProperty(ref selectedAssignment, value))
            {
                if (previousSelectedAssignment != null)
                {
                    if (previousSelectedAssignment.TurnHistory is INotifyCollectionChanged oldColl)
                    {
                        oldColl.CollectionChanged -= TurnHistory_CollectionChanged;
                    }
                }

                previousSelectedAssignment = selectedAssignment;
                RebuildSelectedTurnHistory();

                if (selectedAssignment?.TurnHistory is INotifyCollectionChanged coll)
                {
                    coll.CollectionChanged += TurnHistory_CollectionChanged;
                }

                AddEnemyCommand.NotifyCanExecuteChanged();
                UsePsiSurgeCommand.NotifyCanExecuteChanged();
                OnPropertyChanged(nameof(SelectedCharacterHasPsi));
                OnPropertyChanged(nameof(SelectedCharacterHasSorcery));
            }
        }
    }

    public bool SelectedCharacterHasPsi => SelectedAssignment?.Character.Psi != null;
    public bool SelectedCharacterHasSorcery => SelectedAssignment?.Character.Sorcery != null;

    public EncounterState EncounterState { get; private set; }

    /// <summary>
    /// Populates the enemy picker with the bestiary plus every saved character (loaded as fresh,
    /// independent instances - not the same objects used for "my side" - so a character can be
    /// pitted against another character, or itself, without the two sharing HP/state).
    /// </summary>
    public async Task LoadBestiaryAsync()
    {
        try
        {
            var creatures = PreloadService.Instance.Creatures;
            var characters = await characterService.GetAllAsync().ConfigureAwait(true);

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                AvailableEnemies.Clear();
                foreach (var creature in creatures)
                {
                    AvailableEnemies.Add(creature);
                }
                foreach (var character in characters)
                {
                    AvailableEnemies.Add(character);
                }
                AvailableEnemies.Add(banditPlaceholder);
            }).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    public void AddSingleCharacterToAssignments()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                if (AvailableCharacters.Count == 1)
                {
                    SelectedCharacter = AvailableCharacters[0];
                    AddCharacter();
                    PickRandomEnemy();
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    [RelayCommand]
    private void ToggleShowControls()
    {
        ShowControls = !ShowControls;
    }

    [RelayCommand(CanExecute = nameof(CanAddCharacter))]
    private void AddCharacter()
    {
        if (SelectedCharacter == null)
        {
            return;
        }

        if (Characters.Any(c => c.Id == SelectedCharacter.Id))
        {
            SelectedCharacter = null;
            return;
        }

        SelectedCharacter.LostConsciousness += LostConsciousnessHandler;
        SelectedCharacter.Died += DieHandler;
        SelectedCharacter.SetMaxValues();

        Characters.Add(SelectedCharacter);
        Assignments.Add(new AssignmentViewModel(settings, SelectedCharacter));
        SelectedAssignment ??= Assignments.LastOrDefault();
        AvailableCharacters.Remove(SelectedCharacter);
        SelectedCharacter = null;
    }

    [RelayCommand]
    private void PickRandomEnemy()
    {
        // Restricted to creatures: a character showing up as a random monster encounter would be
        // a confusing surprise, so picking a specific person to fight stays a deliberate choice.
        var randomizableEnemies = AvailableEnemies.OfType<Creature>().ToList();
        SelectedEnemy = EnemyProvider.PickWeightedRandom(randomizableEnemies, e => e.Occurrence.GetWeight());
    }

    /// <summary>
    /// Adds a throwaway ally Character (same generation recipe as BanditGenerator.CreateRandomBandit, fighting
    /// alongside SelectedAssignment's character instead of against them) for a protect-in-combat
    /// quest (see Quest.HasProtectAlly) that character has accepted - picks the quest automatically
    /// if there's exactly one, otherwise asks. Tracked in protectedAllies so DieHandler/EndEncounter
    /// know to fail or complete the quest once the fight resolves.
    /// </summary>
    [RelayCommand]
    private async Task AddProtectedAllyAsync()
    {
        if (SelectedAssignment is not { } assignment)
        {
            return;
        }

        var protector = assignment.Character;
        var protectQuests = PreloadService.Instance.Quests
            .Where(q => q.HasProtectAlly && protector.GetQuestStatus(q) == QuestStatus.Accepted)
            .ToList();

        if (protectQuests.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Protect"),
                String.Format(Lng.Elem("{0} has no accepted quest that needs an ally protected."), protector.Name)).ConfigureAwait(true);
            return;
        }

        Quest quest;
        if (protectQuests.Count == 1)
        {
            quest = protectQuests[0];
        }
        else
        {
            var choice = await ShellNavigationService.DisplayActionSheetAsync(
                "Protect",
                "Cancel",
                null,
                [.. protectQuests.Select(q => Lng.Elem(q.Name))]).ConfigureAwait(true);

            var picked = protectQuests.FirstOrDefault(q => Lng.Elem(q.Name) == choice);
            if (picked == null)
            {
                return;
            }
            quest = picked;
        }

        var ally = BanditGenerator.CreateRandomBandit(settings);
        ally.Name = Lng.Elem(quest.AllyDescription);
        ally.LostConsciousness += LostConsciousnessHandler;
        ally.Died += DieHandler;
        ally.SetMaxValues();

        Characters.Add(ally);
        var allyAssignment = new AssignmentViewModel(settings, ally);
        Assignments.Add(allyAssignment);
        protectedAllies[allyAssignment] = (quest, protector);

        RunTurnCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Seeds this encounter with a specific character and enemy template rather than the
    /// usual manual selection, for flows (like a background-rolled ambush) that already
    /// know exactly who is fighting what.
    /// </summary>
    public void StartAmbush(Character character, Creature enemyTemplate)
    {
        character.LostConsciousness += LostConsciousnessHandler;
        character.Died += DieHandler;
        character.SetMaxValues();

        Characters.Add(character);
        var assignment = new AssignmentViewModel(settings, character);
        Assignments.Add(assignment);
        SelectedAssignment = assignment;

        var existingInAvailable = AvailableCharacters.FirstOrDefault(c => c.Name == character.Name);
        if (existingInAvailable != null)
        {
            AvailableCharacters.Remove(existingInAvailable);
        }

        var setupVm = new EnemySetupViewModel(enemyTemplate);
        ProcessConfirmedEnemies(setupVm.ConfigItems.ToList(), setupVm.MaxSimultaneousAttacks);

        RunTurnCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanAddEnemy))]
    private async Task AddEnemyAsync()
    {
        if (SelectedAssignment == null || SelectedEnemy == null)
        {
            return;
        }

        if (SelectedEnemy is Creature creature)
        {
            var setupVm = new EnemySetupViewModel(creature);
            var setupPage = new EnemySetupPage(setupVm);
            setupVm.OnEnemiesConfirmed += (configs) =>
            {
                ProcessConfirmedEnemies(configs, setupVm.MaxSimultaneousAttacks);
                ShellNavigationService.ClosePageAsync();
            };
            setupVm.OnCancel += () =>
            {
                ShellNavigationService.ClosePageAsync();
            };
            await ShellNavigationService.ShowPageAsync(setupPage).ConfigureAwait(true);
        }
        else if (ReferenceEquals(SelectedEnemy, banditPlaceholder))
        {
            // The "Bandit" list entry is never itself fought - picking it and pressing "Add enemy"
            // spawns a fresh, actually-named bandit (see BanditGenerator) each time instead, so the
            // same entry can be reused to add any number of different bandits.
            var bandit = BanditGenerator.CreateRandomBandit(settings);
            AddEnemyToAssignment(SelectedAssignment!, bandit);
            SelectedEnemy = null;
            RunTurnCommand.NotifyCanExecuteChanged();
        }
        else
        {
            AddEnemyToAssignment(SelectedAssignment!, SelectedEnemy);
            SelectedEnemy = null;
            RunTurnCommand.NotifyCanExecuteChanged();
        }
    }

    /// <summary>
    /// Attaches a non-Bestiary enemy (a generated bandit, or a saved Character picked as an opponent)
    /// directly to an assignment - subscribes the shared LostConsciousness/Died handlers and sets its
    /// starting distance and attack allowance, the same way AddEnemyAsync's non-Creature branch always
    /// has.
    /// </summary>
    private void AddEnemyToAssignment(AssignmentViewModel assignment, Attacker enemy)
    {
        enemy.LostConsciousness += LostConsciousnessHandler;
        enemy.Died += DieHandler;

        assignment.Enemies.Add(enemy);

        // A melee-only opponent (e.g. a generated bandit - see BanditGenerator, which never equips
        // a ranged weapon) starting at the default 20m encounter distance would spend its entire
        // first round just closing the distance instead of ever attacking, which reads as "this
        // enemy's attacks never show up." Start it at melee range instead when it has no ranged
        // attack that could actually make use of the extra distance.
        var startingDistance = enemy.AttackModes.Any(a => a is RangedAttack)
            ? GameSystem.Constants.DefaultEncounterDistance
            : Attacker.MeleeDistance;
        assignment.SetDistance(enemy, startingDistance);

        // MaxSimultaneousAttacks is otherwise only ever set by the Creature/EnemySetupPage flow
        // (ProcessConfirmedEnemies) - an assignment whose first enemy comes in through this path
        // instead (a bandit, or any enemy added without ever opening that setup dialog) stays at its
        // default 0, and EncounterHelpers.GetInitiativesInternalAsync's "if (result.Count <
        // MaxSimultaneousAttacks)" gate then blocks every enemy in the assignment from ever generating
        // an attack initiative - forever, not just occasionally. That's the actual reason a generated
        // bandit's own attacks (and even its movement, once it reaches range) never appeared in the
        // EncounterPage turn log, no matter how tough the bandit was. Bump it up to at least 1 rather
        // than overwrite a higher value a prior Creature setup may have already established.
        assignment.MaxSimultaneousAttacks = Math.Max(assignment.MaxSimultaneousAttacks, 1);
    }

    private bool CanUsePsiSurge() => SelectedAssignment?.Character is { Psi: not null } character &&
        character.PsiPoints + character.DynamicAstralPsiShield + character.DynamicMentalPsiShield > 0;

    /// <summary>
    /// Roham (Megfékezés) — book p.118-119 all-or-nothing discipline: burns every currently
    /// available psi point (free ones plus anything parked in a Dinamikus Pajzs) either on the
    /// caster's own attack (Roham) or to weaken a chosen opponent's attack (Megfékezés). There is
    /// no partial-amount option, unlike the old per-point prompt this replaced.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanUsePsiSurge))]
    private async Task UsePsiSurgeAsync()
    {
        if (SelectedAssignment?.Character is not { Psi: not null } character)
        {
            return;
        }

        var total = character.PsiPoints + character.DynamicAstralPsiShield + character.DynamicMentalPsiShield;

        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Psi surge",
            "Cancel",
            null,
            "Roham",
            "Megfékezés").ConfigureAwait(true);

        switch (choice)
        {
            case "Roham":
                var confirmRoham = await ShellNavigationService.DisplayAlertAsync(
                    "Psi surge",
                    String.Format(
                        Lng.Elem("Burn all {0} psi points (including any held in a Dinamikus Pajzs) for +{1} attack value each, for this round only?"),
                        total,
                        Character.PsiSurgeAttackValuePerPoint),
                    Lng.Elem("Roham"),
                    Lng.Elem("Cancel")).ConfigureAwait(true);

                if (confirmRoham)
                {
                    character.TryUsePsiSurge();
                }
                break;

            case "Megfékezés":
                var enemies = SelectedAssignment.Enemies;
                if (enemies.Count == 0)
                {
                    await ShellNavigationService.DisplayAlertAsync(Lng.Elem("No enemy assigned to weaken.")).ConfigureAwait(true);
                    break;
                }

                var enemyNames = enemies.Select(e => e.Name).ToArray();
                var enemyChoice = await ShellNavigationService.DisplayActionSheetAsync(
                    "Megfékezés",
                    "Cancel",
                    null,
                    enemyNames).ConfigureAwait(true);

                var target = enemies.FirstOrDefault(e => e.Name == enemyChoice);
                if (target != null)
                {
                    character.TryUseMegfekezes(target);
                }
                break;
        }

        UsePsiSurgeCommand.NotifyCanExecuteChanged();
    }

    private bool CanDismantlePsiShield() => SelectedAssignment?.Character.Psi != null;

    /// <summary>
    /// Combat only allows tearing a psi shield back down - building one (spending points on a new
    /// Statikus Pajzs, or feeding a Dinamikus Pajzs) takes place ahead of time on the character's
    /// details page (see CharacterViewModel.BuildPsiShieldAsync), not mid-fight.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanDismantlePsiShield))]
    private async Task DismantlePsiShieldAsync()
    {
        if (SelectedAssignment?.Character is not { Psi: not null } character)
        {
            return;
        }

        var options = new List<string>();
        if (character.StaticAstralPsiShield > 0)
        {
            options.Add("Static astral");
        }
        if (character.StaticMentalPsiShield > 0)
        {
            options.Add("Static mental");
        }
        if (character.DynamicAstralPsiShield > 0)
        {
            options.Add("Dynamic astral");
        }
        if (character.DynamicMentalPsiShield > 0)
        {
            options.Add("Dynamic mental");
        }

        if (options.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("This character has no psi shield to dismantle.")).ConfigureAwait(true);
            return;
        }

        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Psi shield",
            "Cancel",
            null,
            [.. options]).ConfigureAwait(true);

        switch (choice)
        {
            case "Static astral":
                character.RemoveStaticPsiShield(true);
                break;
            case "Static mental":
                character.RemoveStaticPsiShield(false);
                break;
            case "Dynamic astral":
                character.TryAdjustDynamicPsiShield(true, -character.DynamicAstralPsiShield);
                break;
            case "Dynamic mental":
                character.TryAdjustDynamicPsiShield(false, -character.DynamicMentalPsiShield);
                break;
        }

        UsePsiSurgeCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Two-step attack-mode picker: MAUI's Picker control has no grouping/section support, so instead
    /// of one flat dropdown mixing weapons, psi disciplines and spells, this asks for a category
    /// first (Auto/Weapon/Psi/Magic - only the categories the character actually has something in),
    /// then the specific attack within it.
    /// </summary>
    [RelayCommand]
    private async Task SelectAttackModeAsync(AssignmentViewModel assignment)
    {
        if (assignment == null)
        {
            return;
        }

        const string autoLabel = "Auto (first attack)";
        const string weaponLabel = "Weapon";
        const string psiLabel = "Psi";
        const string magicLabel = "Magic";

        var weaponModes = assignment.Character.AttackModes.Where(a => a is MeleeAttack or RangedAttack).ToList();
        var psiModes = assignment.Character.AttackModes.OfType<PsiAttack>().Cast<Attack>().ToList();
        var magicModes = assignment.Character.AttackModes.OfType<SpellAttack>().Cast<Attack>().ToList();

        var categories = new List<string> { autoLabel };
        if (weaponModes.Count > 0)
        {
            categories.Add(weaponLabel);
        }
        if (psiModes.Count > 0)
        {
            categories.Add(psiLabel);
        }
        if (magicModes.Count > 0)
        {
            categories.Add(magicLabel);
        }

        var categoryChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Attack mode",
            "Cancel",
            null,
            [.. categories]).ConfigureAwait(true);

        // DisplayActionSheetAsync translates each button label via Lng.Elem(), so the returned choice
        // must be matched back the same way - comparing against the raw labels only matches by luck,
        // whenever the current language happens to have no translation entry for them.
        if (categoryChoice == Lng.Elem(autoLabel))
        {
            assignment.SelectedAttackMode = null;
            return;
        }

        var modes = categoryChoice switch
        {
            _ when categoryChoice == Lng.Elem(weaponLabel) => weaponModes,
            _ when categoryChoice == Lng.Elem(psiLabel) => psiModes,
            _ when categoryChoice == Lng.Elem(magicLabel) => magicModes,
            _ => []
        };

        if (modes.Count == 0)
        {
            return;
        }

        var modeChoice = await ShellNavigationService.DisplayActionSheetAsync(
            categoryChoice,
            "Cancel",
            null,
            [.. modes.Select(m => Lng.Elem(m.Name))]).ConfigureAwait(true);

        var selected = modes.FirstOrDefault(m => Lng.Elem(m.Name) == modeChoice);
        if (selected != null)
        {
            assignment.SelectedAttackMode = selected;
        }
    }

    [RelayCommand]
    private async Task EmpowerSpellAsync()
    {
        if (SelectedAssignment is not { } assignment)
        {
            return;
        }

        if (assignment.SelectedAttackMode is not SpellAttack spellAttack)
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("Select a spell as the attack mode first.")).ConfigureAwait(true);
            return;
        }

        var character = assignment.Character;
        var spell = spellAttack.Spell;

        var pointsText = await ShellNavigationService.DisplayPromptAsync(
            "Empower spell",
            String.Format(
                Lng.Elem("Spend how many extra mana points (max {0}) on {1}, for +{2} power each this round?"),
                character.ManaPoints,
                Lng.Elem(spell.Name),
                spell.PowerBonusPerManaPoint),
            "OK",
            "Cancel",
            character.ManaPoints.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(pointsText) ||
            !int.TryParse(pointsText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var points))
        {
            return;
        }

        if (!character.TryEmpowerSpell(spell, points))
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("Not enough mana points.")).ConfigureAwait(true);
        }
    }

    [RelayCommand(CanExecute = nameof(CanRunTurn))]
    private async Task RunTurnAsync()
    {
        if (IsRunningTurns)
        {
            return;
        }

        try
        {
            var runUntilFinished = settings.CombatSimulatorMode == CombatSimulatorMode.FullAuto;
            await RunTurnsAsync(runUntilFinished).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
    
    private ICombatRollService CreateCombatRollService()
    {
        return settings.CombatSimulatorMode == CombatSimulatorMode.Manual
            ? new ManualCombatRollService(soundPlayer, shakeService)
            : new AutoCombatRollService();
    }

    private async Task RunTurnsAsync(bool runUntilFinished)
    {
        if (await TryPrepareEncounterAsync().ConfigureAwait(true))
        {
            return;
        }

        await SetTurnRunningStateAsync(true).ConfigureAwait(false);

        try
        {
            var rollService = CreateCombatRollService();

            do
            {
                await RunSingleRoundAsync(rollService).ConfigureAwait(false);
            }
            while (runUntilFinished && !IsEncounterOver());
        }
        finally
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                IsRunningTurns = false;
                RunTurnCommand.NotifyCanExecuteChanged();

                if (IsEncounterOver())
                {
                    EndEncounter();
                }
            }).ConfigureAwait(false);
        }
    }

    private Task SetTurnRunningStateAsync(bool isRunning)
    {
        return MainThread.InvokeOnMainThreadAsync(() =>
        {
            IsRunningTurns = isRunning;
            ShowControls = !isRunning;
            RunTurnCommand.NotifyCanExecuteChanged();
        });
    }

    private async Task<bool> TryPrepareEncounterAsync()
    {
        var hasEnemies = Assignments.Any(a => a.Enemies?.Count > 0);
        if (!hasEnemies && SelectedEnemy is Creature autoCreature)
        {
            var setupVm = new EnemySetupViewModel(autoCreature);
            var configs = setupVm.ConfigItems.ToList();
            ProcessConfirmedEnemies(configs, setupVm.MaxSimultaneousAttacks);
            SelectedEnemy = null;
            RunTurnCommand.NotifyCanExecuteChanged();
            AddSingleCharacterToAssignments();
            return true;
        }

        if (IsEncounterOver())
        {
            await NewEncounter().ConfigureAwait(false);
            AddSingleCharacterToAssignments();
            return true;
        }

        return false;
    }

    private async Task RunSingleRoundAsync(ICombatRollService rollService)
    {
        var assignmentsSnapshot = Assignments.ToList();

        foreach (var assignment in assignmentsSnapshot)
        {
            if (assignment.IsFinished || assignment.Character.IsDead)
            {
                continue;
            }

            if (!assignment.Enemies.Any(e => !e.IsDead))
            {
                continue;
            }

            var round = assignment.TurnHistory.Count + 1;
            await CombatEngine.ProcessAssignmentTurnAsync(assignment, round, rollService).ConfigureAwait(false);
        }
    }

    private void RebuildSelectedTurnHistory()
    {
        SelectedTurnHistory.Clear();
        if (SelectedAssignment == null)
        {
            return;
        }

        var src = SelectedAssignment.TurnHistory;
        IEnumerable<TurnViewModel> items = settings.AssignmentTurnHistoryNewestOnTop ? src.Reverse() : src;
        foreach (var t in items)
        {
            SelectedTurnHistory.Add(t);
        }
    }

    private void TurnHistory_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (TurnViewModel newTurn in e.NewItems)
                {
                    if (settings.AssignmentTurnHistoryNewestOnTop)
                    {
                        SelectedTurnHistory.Insert(0, newTurn);
                    }
                    else
                    {
                        SelectedTurnHistory.Add(newTurn);
                    }
                }
            }
            else
            {
                RebuildSelectedTurnHistory();
            }
        });
    }

    private Task NewEncounter()
    {
        Dispose();
        Assignments.Clear();
        Characters.Clear();
        protectedAllies.Clear();
        return LoadCharactersAsync();
    }

    private void DieHandler(object? sender, EventArgs e)
    {
        if (sender is not Attacker diedEntity)
        {
            return;
        }

        diedEntity.Died -= DieHandler;
        diedEntity.LostConsciousness -= LostConsciousnessHandler;

        var charAssignment = Assignments.FirstOrDefault(a => a.Character == diedEntity);
        var enemyAssignment = Assignments.FirstOrDefault(a => a.Enemies.Contains(diedEntity));
        var eventAssignment = charAssignment ?? enemyAssignment;

        if (charAssignment != null && protectedAllies.TryGetValue(charAssignment, out var protectedInfo))
        {
            protectedInfo.Protector.FailQuest(protectedInfo.Quest);
            protectedAllies.Remove(charAssignment);
            _ = characterService.SaveAsync(protectedInfo.Protector);

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
                Lng.Elem("Quest failed"),
                String.Format(Lng.Elem("{0} falls - \"{1}\" can no longer be protected."), diedEntity.Name, Lng.Elem(protectedInfo.Quest.Name))));
        }

        if (enemyAssignment != null)
        {
            AddXp(enemyAssignment.Character, diedEntity);
            CompleteMatchingQuests(enemyAssignment.Character, diedEntity);
            _ = OfferLootAsync(enemyAssignment.Character, diedEntity);
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                if (charAssignment != null)
                {
                    var enemiesToRedistribute = charAssignment.Enemies.ToList();
                    charAssignment.Enemies.Clear();
                    charAssignment.IsFinished = true;
                    RedistributeEnemies(enemiesToRedistribute);
                }
                else if (enemyAssignment != null)
                {
                    enemyAssignment.RemoveEnemyDistance(diedEntity);
                    enemyAssignment.Enemies.Remove(diedEntity);

                    if (enemyAssignment.Enemies.Count == 0)
                    {
                        RedistributeSurplusEnemies(enemyAssignment);
                    }
                }

                RunTurnCommand.NotifyCanExecuteChanged();

                if (IsEncounterOver())
                {
                    EndEncounter();
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    private bool IsEncounterOver()
    {
        var activeAssignments = Assignments.Where(a => !a.IsFinished).ToList();
        if (activeAssignments.Count == 0)
        {
            return true;
        }

        var anyAliveCharacter = activeAssignments.Any(a => !a.Character.IsDead);
        if (!anyAliveCharacter)
        {
            return true;
        }

        var anyAliveEnemy = activeAssignments.SelectMany(a => a.Enemies).Any(e => !e.IsDead);
        if (!anyAliveEnemy)
        {
            return true;
        }

        return false;
    }

    private void EndEncounter()
    {
        foreach (var assignment in Assignments)
        {
            assignment.Character.LostConsciousness -= LostConsciousnessHandler;
            assignment.Character.Died -= DieHandler;
            RemoveEnemyHandlers(assignment.Enemies);
        }

        // Any protect-in-combat ally still tracked here made it through the whole fight alive - a
        // dead one was already removed from protectedAllies (and failed) by DieHandler.
        foreach (var (allyAssignment, protectedInfo) in protectedAllies)
        {
            protectedInfo.Protector.CompleteQuest(protectedInfo.Quest);
            _ = characterService.SaveAsync(protectedInfo.Protector);

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
                Lng.Elem("Quest complete"),
                String.Format(
                    Lng.Elem("{0} survives the fight. \"{1}\" is complete - {2}{3}."),
                    allyAssignment.Character.Name,
                    Lng.Elem(protectedInfo.Quest.Name),
                    protectedInfo.Quest.MoneyReward.ToTranslatedString(),
                    protectedInfo.Quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), protectedInfo.Quest.ExperienceReward) : String.Empty)));
        }
        protectedAllies.Clear();

        ShowControls = true;
        EncounterState = EncounterState.Finished;
        RunTurnCommand.NotifyCanExecuteChanged();
    }

    private void LostConsciousnessHandler(object? sender, EventArgs e)
    {
    }

    private void ProcessConfirmedEnemies(List<EnemyConfigurationItem> configs, int maxSimultaneousAttacks)
    {
        foreach (var config in configs)
        {
            var newEnemy = config.CreateInstance();
            newEnemy.AttackDirection = config.Direction;
            newEnemy.AttackStrategy = config.Strategy;
            newEnemy.LostConsciousness += LostConsciousnessHandler;
            newEnemy.Died += DieHandler;

            if (config.SelectedAttackMode != null)
            {
                newEnemy.PreferredAttackMode = config.SelectedAttackMode;
            }

            SelectedAssignment!.Enemies.Add(newEnemy);
            SelectedAssignment.SetDistance(newEnemy, config.Distance);
            SelectedAssignment.MaxSimultaneousAttacks = maxSimultaneousAttacks;
        }

        SelectedEnemy = null;
        RunTurnCommand.NotifyCanExecuteChanged();
    }

    private bool CanAddEnemy() => SelectedEnemy != null && SelectedAssignment != null;

    private bool CanAddCharacter() => SelectedCharacter != null && !Characters.Any(c => c.Id == SelectedCharacter.Id);

    private bool CanRunTurn() => Assignments.Count > 0;

    private void RemoveEnemyHandlers(IEnumerable<Attacker> attackers)
    {
        foreach (var enemy in attackers)
        {
            enemy.LostConsciousness -= LostConsciousnessHandler;
            enemy.Died -= DieHandler;
        }
    }

    private void RedistributeEnemies(IEnumerable<Attacker> enemies)
    {
        var enemiesList = enemies.ToList();
        if (Assignments.Count == 0)
        {
            RemoveEnemyHandlers(enemiesList);
            return;
        }

        var index = 0;
        foreach (var enemy in enemiesList)
        {
            Assignments[index % Assignments.Count].Enemies.Add(enemy);
            index++;
        }
    }

    /// <summary>
    /// Called when a character finishes off every enemy assigned to them while other assignments still
    /// have some left - without this, that character would just stand idle for the rest of the
    /// encounter (see DieHandler) instead of being handed a share of the remaining fight, the way
    /// RedistributeEnemies already does for a dead character's leftover enemies.
    /// </summary>
    private void RedistributeSurplusEnemies(AssignmentViewModel emptiedAssignment)
    {
        var donor = Assignments
            .Where(a => a != emptiedAssignment && !a.IsFinished && a.Enemies.Count > 1)
            .OrderByDescending(a => a.Enemies.Count)
            .FirstOrDefault();

        if (donor == null)
        {
            return;
        }

        var enemy = donor.Enemies[^1];
        donor.Enemies.Remove(enemy);
        donor.RemoveEnemyDistance(enemy);
        emptiedAssignment.Enemies.Add(enemy);
    }

    private void AddXp(Attacker attacker, Attacker target)
    {
        if (attacker is Character character)
        {
            if (target is Creature creature)
            {
                character.BaseClass!.ExperiencePoints += creature.ExperiencePoints;
            }
            else if (target is Character targetCharacter)
            {
                character.BaseClass!.ExperiencePoints += targetCharacter.BaseClass.ExperiencePoints;
            }
            _ = characterService.SaveAsync(character);
        }
    }

    /// <summary>
    /// Auto-completes any of this character's accepted quests whose Quest.TargetCreatureName
    /// matches the creature that just died - e.g. a bounty on wolves finishes itself the moment a
    /// Wolf falls, without the player needing to press "Mark complete" by hand. A killed Character
    /// flagged IsGeneratedEnemy (see BanditGenerator) instead matches quests with
    /// TargetIsGeneratedBandit, for combat quests with no dedicated Bestiary type. Quests with
    /// neither (investigation, negotiation, ...) are unaffected and stay manual-only.
    /// </summary>
    private void CompleteMatchingQuests(Attacker attacker, Attacker target)
    {
        if (attacker is not Character character)
        {
            return;
        }

        List<Quest> matchingQuests;
        if (target is Creature creature)
        {
            var creatureName = creature.GetType().Name;
            matchingQuests = PreloadService.Instance.Quests
                .Where(q => q.TargetCreatureName == creatureName && character.GetQuestStatus(q) == QuestStatus.Accepted)
                .ToList();
        }
        else if (target is Character { IsGeneratedEnemy: true })
        {
            matchingQuests = PreloadService.Instance.Quests
                .Where(q => q.TargetIsGeneratedBandit && character.GetQuestStatus(q) == QuestStatus.Accepted)
                .ToList();
        }
        else
        {
            return;
        }

        if (matchingQuests.Count == 0)
        {
            return;
        }

        foreach (var quest in matchingQuests)
        {
            character.CompleteQuest(quest);

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
                Lng.Elem("Quest complete"),
                String.Format(Lng.Elem("{0} completes \"{1}\"."), character.Name, Lng.Elem(quest.Name))));
        }

        _ = characterService.SaveAsync(character);
    }

    /// <summary>
    /// Lets the killer take equipment off whatever they just defeated - a Creature's real Weapon/Armor
    /// Things (pulled out of AttackModes/Armor, see GetLootableItems) for a Bestiary kill, or the
    /// fallen Character's own Equipment for a bandit/NPC kill (see BanditGenerator). Offered one item
    /// at a time so the player can pick and choose rather than an all-or-nothing grab.
    /// </summary>
    private async Task OfferLootAsync(Character looter, Attacker diedEntity)
    {
        var lootable = GetLootableItems(diedEntity);
        if (lootable.Count == 0)
        {
            return;
        }

        var takeAllLabel = Lng.Elem("Take everything");
        var leaveLabel = Lng.Elem("Leave it");

        while (lootable.Count > 0)
        {
            var options = new List<string> { takeAllLabel };
            options.AddRange(lootable.Select(item => Lng.Elem(item.Name)));

            var choice = await ShellNavigationService.DisplayActionSheetAsync(
                String.Format(Lng.Elem("Loot {0}"), Lng.Elem(diedEntity.Name)),
                leaveLabel,
                null,
                [.. options]).ConfigureAwait(true);

            if (choice == null || choice == leaveLabel)
            {
                break;
            }

            if (choice == takeAllLabel)
            {
                foreach (var item in lootable)
                {
                    looter.AddEquipment(item);
                    (diedEntity as Character)?.RemoveEquipment(item);
                }
                lootable.Clear();
                break;
            }

            var picked = lootable.FirstOrDefault(item => Lng.Elem(item.Name) == choice);
            if (picked == null)
            {
                break;
            }

            looter.AddEquipment(picked);
            (diedEntity as Character)?.RemoveEquipment(picked);
            lootable.Remove(picked);
        }

        await characterService.SaveAsync(looter).ConfigureAwait(false);

        // Don't persist a BanditGenerator throwaway - it was never saved to begin with and isn't
        // meant to become a permanent entry in the character list.
        if (diedEntity is Character { IsGeneratedEnemy: false } diedCharacter)
        {
            await characterService.SaveAsync(diedCharacter).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Real, catalog Things worth looting off a defeated Attacker - for a Creature, the actual Weapon
    /// instances behind its MeleeAttack/RangedAttack modes plus non-natural Armor, skipping the
    /// generic ad-hoc attack shapes (BodyPart claws/bites, CommonWeapon/CommonRangedWeapon/BreathWeapon)
    /// that exist only for combat math and were never meant to be equipped by a Character. For a
    /// Character (e.g. a BanditGenerator-spawned NPC), its own Equipment is already the real thing.
    /// </summary>
    private static List<Thing> GetLootableItems(Attacker diedEntity)
    {
        if (diedEntity is Character character)
        {
            return [.. character.Equipment];
        }

        if (diedEntity is not Creature creature)
        {
            return [];
        }

        var items = new List<Thing>();

        foreach (var attack in creature.AttackModes)
        {
            var weapon = attack switch
            {
                MeleeAttack { Weapon: Weapon w } => w,
                RangedAttack { Weapon: Weapon w } => w,
                _ => null
            };

            if (weapon != null && !IsGenericAttackShape(weapon))
            {
                items.Add(weapon);
            }
        }

        if (creature.Armor is { } armor && armor is not NaturalArmor)
        {
            items.Add(armor);
        }

        return items;
    }

    private static bool IsGenericAttackShape(Weapon weapon) =>
        weapon.GetType() == typeof(BodyPart) ||
        weapon.GetType() == typeof(CommonWeapon) ||
        weapon.GetType() == typeof(CommonRangedWeapon) ||
        weapon.GetType() == typeof(BreathWeapon);

    public void Dispose()
    {
        foreach (var character in Characters)
        {
            character.LostConsciousness -= LostConsciousnessHandler;
            character.Died -= DieHandler;
        }

        foreach (var assignment in Assignments)
        {
            RemoveEnemyHandlers(assignment.Enemies);
        }

        try
        {
            shakeService?.Dispose();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}
