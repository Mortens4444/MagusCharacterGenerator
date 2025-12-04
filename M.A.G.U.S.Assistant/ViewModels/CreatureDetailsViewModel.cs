using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.Extensions.Services;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CreatureDetailsViewModel : ObservableObject
{
    private readonly ISoundPlayer soundPlayer;

    public Creature Creature { get; init; }

    public ICommand InitiateCommand { get; }
    public ICommand AttackCommand { get; }
    public ICommand RollDamageCommand { get; }

    public CreatureDetailsViewModel(ISoundPlayer soundPlayer, Creature creature)
    {
        this.soundPlayer = soundPlayer;
        Creature = creature ?? throw new ArgumentNullException(nameof(creature));

        var method = creature.GetType().GetMethod(nameof(creature.GetNumberAppearing));
        var throwType = method?.GetCustomAttribute<DiceThrowAttribute>()?.DiceThrowType;
        var modifier = method?.GetCustomAttribute<DiceThrowModifierAttribute>()?.Modifier;

        var rolled = creature.GetNumberAppearing();

        if (throwType != null)
        {
            var desc = Lng.Elem(throwType.Value.GetDescription());
            var modText = modifier.HasValue && modifier.Value != 0
                ? (modifier.Value > 0 ? $" + {modifier.Value}" : $" - {Math.Abs(modifier.Value)}")
                : String.Empty;

            NumberAppearing = $"{desc}{modText} = {rolled.ToString(CultureInfo.InvariantCulture)}";
        }
        else
        {
            NumberAppearing = rolled.ToString(CultureInfo.InvariantCulture);
        }

        InitiateCommand = new Command(OnInitiate);
        AttackCommand = new Command(OnAttack);
        RollDamageCommand = new Command(OnRollDamage);
        LastAction = String.Empty;
    }

    public string Occurrence => Creature.Occurrence.ToString();
    public string Intelligence => Creature.Intelligence.ToString();
    public M.A.G.U.S.Enums.Size Size => Creature.Size;
    public int Speed => Creature.Speed;
    public int AttackValue => Creature.AttackValue;
    public int DefenseValue => Creature.DefenseValue;
    public int InitiatingValue => Creature.InitiatingValue;
    public byte? HealthPoints => Creature.HealthPoints;
    public byte? PainTolerancePoints => Creature.PainTolerancePoints;
    public byte? PoisonResistance => Creature.PoisonResistance;
    public uint ExperiencePoints => Creature.ExperiencePoints;
    public double AttacksPerRound => Creature.AttacksPerRound;
    public string Image => Creature.Images.Length - 1 != 0 ? Creature.Images[RandomProvider.GetSecureRandomInt(0, Creature.Images.Length)] : Creature.Images[0];
    public string Sound => Creature.Sounds.Length - 1 != 0 ? Creature.Sounds[RandomProvider.GetSecureRandomInt(0, Creature.Sounds.Length)] : Creature.Sounds[0];

    private string numberAppearing;
    public string NumberAppearing
    {
        get => numberAppearing;
        set => SetProperty(ref numberAppearing, value);
    }

    private PlaceOfAttack hitLocation;
    private string placeOfAttack;
    public string PlaceOfAttack
    {
        get => placeOfAttack;
        set => SetProperty(ref placeOfAttack, value);
    }

    private string lastActionName;
    public string LastActionName
    {
        get => lastActionName;
        set => SetProperty(ref lastActionName, value);
    }

    private string lastAction;
    public string LastAction
    {
        get => lastAction;
        set => SetProperty(ref lastAction, value);
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
            LastAction = Creature.GetInitiate().ToString();
        }
        catch (Exception ex)
        {
            LastActionName = Lng.Elem("Error");
            LastAction = ex.Message;
        }
    }

    private void OnAttack()
    {
        try
        {
            hitLocation = HitLocationSelector.Get();
            PlaceOfAttack = Lng.Elem(hitLocation.GetDescription());
            LastActionName = Lng.Elem("Attack");
            var (impact, value) = Creature.GetAttack();
            LastAction = impact == AttackImpact.Normal ? value.ToString() : $"{Lng.Elem(impact.ToString())} {value}";
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
            var dmg = Creature.GetDamage();
            var final = (byte)(hitLocation == M.A.G.U.S.Enums.PlaceOfAttack.Head ? dmg * 2 : dmg);
            LastActionName = Lng.Elem("Damage");
            LastAction = final.ToString();
        }
        catch (Exception ex)
        {
            LastActionName = Lng.Elem("Error");
            LastAction = ex.Message;
        }
    }
}
