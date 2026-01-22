using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Utils;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Globalization;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CreatureDetailsViewModel : BaseViewModel
{
    private readonly ISoundPlayer soundPlayer;
    private string lastActionName;
    private string lastAction;
    private bool isSoundAvailable;
    private AttackDirection selectedAttackDirection;
    private string numberAppearing;
    private readonly PlaceOfAttack hitLocation;
    private string placeOfAttack;
    private AsyncRelayCommand? previewImageCommand;

    public Creature Creature { get; init; }
    public Attack SelectedAttackMode { get; set; }

    public ICommand InitiateCommand { get; }
    public ICommand AttackCommand { get; }
    public ICommand RollDamageCommand { get; }

    public CreatureDetailsViewModel(ISoundPlayer soundPlayer, Creature creature)
    {
        this.soundPlayer = soundPlayer;
        Creature = creature ?? throw new ArgumentNullException(nameof(creature));
        SelectedAttackMode = AttackModes.First();
        SelectedAttackDirection = AttackDirections.First();
        IsSoundAvailable = Creature.Sounds.Any(s => !String.IsNullOrWhiteSpace(s) && EmbeddedResourceHelper.HasEmbeddedSound(s));

        var method = creature.GetType().GetMethod(nameof(creature.GetNumberAppearing));
        NumberAppearing = DiceThrowFormatter.FormatResult(method, () => creature.GetNumberAppearing());

        InitiateCommand = new Command(OnInitiate);
        AttackCommand = new Command(OnAttack);
        RollDamageCommand = new Command(OnRollDamage);
        LastAction = String.Empty;
    }

    public Occurrence Occurrence => Creature.Occurrence;
    public Intelligence? Intelligence => Creature.Intelligence;
    public Intelligence? MinIntelligence => Creature.MinIntelligence;
    public Intelligence? MaxIntelligence => Creature.MaxIntelligence;
    public M.A.G.U.S.Enums.Size Size => Creature.Size;
    public List<Speed> Speeds => Creature.Speeds;
    public int AttackValue => Creature.AttackValue;
    public int DefenseValue => Creature.DefenseValue;
    public int InitiateValue => Creature.InitiateValue;
    public string HealthPoints => Creature.DisplayHealthPoints;
    public string PainTolerancePoints => Creature.DisplayPainTolerancePoints;
    public IList<Attack> AttackModes => Creature.AttackModes;
    public string AstralMagicResistance => !Creature.AstralMagicResistance.HasValue ? "-" : Creature.AstralMagicResistance.Value == Int32.MaxValue ? Lng.Elem("Immune") : Creature.AstralMagicResistance.Value.ToString(CultureInfo.InvariantCulture);
    public string MentalMagicResistance => !Creature.MentalMagicResistance.HasValue ? "-" : Creature.MentalMagicResistance == Int32.MaxValue ? Lng.Elem("Immune") : Creature.MentalMagicResistance.Value.ToString(CultureInfo.InvariantCulture);
    public string PoisonResistance => !Creature.PoisonResistance.HasValue ? "-" : Creature.PoisonResistance == Int32.MaxValue ? Lng.Elem("Immune") : Creature.PoisonResistance.Value.ToString(CultureInfo.InvariantCulture);
    public ulong ExperiencePoints => Creature.ExperiencePoints;
    public double AttacksPerRound => Creature.AttacksPerRound;
    public string RandomImage => Creature.RandomImage;
    public string Sound => Creature.Sounds.Length > 1 ? Creature.Sounds[RandomProvider.GetSecureRandomInt(0, Creature.Sounds.Length)] : Creature.Sounds[0];

    public IList<AttackDirection> AttackDirections { get; } = [.. Enum.GetValues<AttackDirection>()];

    public AttackDirection SelectedAttackDirection
    {
        get => selectedAttackDirection;
        set => SetProperty(ref selectedAttackDirection, value);
    }

    public string NumberAppearing
    {
        get => numberAppearing;
        set => SetProperty(ref numberAppearing, value);
    }

    public string PlaceOfAttack
    {
        get => placeOfAttack;
        set => SetProperty(ref placeOfAttack, value);
    }

    public string LastActionName
    {
        get => lastActionName;
        set => SetProperty(ref lastActionName, value);
    }

    public string LastAction
    {
        get => lastAction;
        set => SetProperty(ref lastAction, value);
    }

    public bool IsSoundAvailable
    {
        get => isSoundAvailable;
        set => SetProperty(ref isSoundAvailable, value);
    }

    [RelayCommand]
    public async Task PlaySoundAsync()
    {
        try
        {
            if (!String.IsNullOrWhiteSpace(Sound))
            {
                await soundPlayer.PlayAsync(Sound).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
#if DEBUG
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
#endif
        }
    }

    private void OnInitiate()
    {
        try
        {
            PlaceOfAttack = String.Empty;
            LastActionName = Lng.Elem("Initiate");
            LastAction = Creature.GetInitiate().ToString(CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            LastActionName = Lng.Elem("Error");
            LastAction = ex.Message;
        }
    }

    private void OnAttack()
    {
        if (SelectedAttackMode == null)
        {
            return;
        }

        try
        {
            var (locationDescription, subLocation) = HitLocationSelector.GetLocation(SelectedAttackDirection);
            PlaceOfAttack = String.IsNullOrEmpty(subLocation) ? locationDescription : $"{Lng.Elem(locationDescription)} ({Lng.Elem(subLocation)})";
            LastActionName = $"{Lng.Elem(SelectedAttackMode is MeleeAttack ? "Melee attack" : "Ranged attack")} - {Lng.Elem(SelectedAttackMode.Name)}";
            var (impact, value) = SelectedAttackMode.GetAttack();
            LastAction = impact == AttackImpact.Normal ? value.ToString(CultureInfo.InvariantCulture) : $"{Lng.Elem(impact.ToString())} {value}";
        }
        catch (Exception ex)
        {
            LastActionName = Lng.Elem("Error");
            LastAction = ex.Message;
        }
    }

    private void OnRollDamage()
    {
        try
        {
            var doubleDamage = hitLocation == M.A.G.U.S.Enums.PlaceOfAttack.Head;
            var dmg = SelectedAttackMode.GetDamage();
            var final = doubleDamage ? dmg * 2 : dmg;

            if (AttackModes.Count == 1)
            {
                var method = Creature.GetType().GetMethod(nameof(Creature.GetDamage));
                LastAction = DiceThrowFormatter.FormatResult(method, final);
            }
            else
            {
                if (SelectedAttackMode is MeleeAttack meleeAttack)
                {
                    if (meleeAttack.Weapon is BodyPart bodyPart)
                    {
                        LastAction = DiceThrowFormatter.FormatResult(final, bodyPart.ThrowType, bodyPart.Modifier);
                    }
                    else
                    {
                        var method = meleeAttack.Weapon?.GetType().GetMethod(nameof(meleeAttack.Weapon.GetDamage));
                        LastAction = DiceThrowFormatter.FormatResult(method, final);
                    }
                }
                else if (SelectedAttackMode is RangeAttack rangeAttack)
                {
                    if (rangeAttack.Weapon is BreathWeaponcs breathWeaponcs)
                    {
                        LastAction = DiceThrowFormatter.FormatResult(final, breathWeaponcs.ThrowType, breathWeaponcs.Modifier);
                    }
                    else
                    {
                        var method = rangeAttack.Weapon.GetType().GetMethod(nameof(meleeAttack.Weapon.GetDamage));
                        LastAction = DiceThrowFormatter.FormatResult(method, final);
                    }
                }
                else
                {
                    LastAction = final.ToString(CultureInfo.InvariantCulture);
                }
            }

            LastActionName = doubleDamage ? $"{Lng.Elem("Double damage")} - {Lng.Elem(SelectedAttackMode.Name)}" : $"{Lng.Elem("Damage")} - {Lng.Elem(SelectedAttackMode.Name)}";
        }
        catch (Exception ex)
        {
            LastActionName = Lng.Elem("Error");
            LastAction = ex.Message;
        }
    }

    public IAsyncRelayCommand PreviewImageCommand => previewImageCommand ??= new AsyncRelayCommand(PreviewImage);

    private Task PreviewImage()
    {
        return ImagePreviewService.ShowAsync(RandomImage);
    }
}
