using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.Extensions.Services;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CreatureDetailsViewModel : ObservableObject
{
    private readonly ISoundPlayer soundPlayer;

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
        IsSoundAvailable = Creature.Sounds.Any(s => !String.IsNullOrWhiteSpace(s) && EmbeddedResourceHelper.HasEmbeddedSound(s));

        var method = creature.GetType().GetMethod(nameof(creature.GetNumberAppearing));
        NumberAppearing = DiceThrowFormatter.FormatResult(method, () => creature.GetNumberAppearing());

        InitiateCommand = new Command(OnInitiate);
        AttackCommand = new Command(OnAttack);
        RollDamageCommand = new Command(OnRollDamage);
        LastAction = String.Empty;
    }

    public Occurrence Occurrence => Creature.Occurrence;
    public Intelligence Intelligence => Creature.Intelligence;
    public M.A.G.U.S.Enums.Size Size => Creature.Size;
    public int Speed => Creature.Speed;
    public int AttackValue => Creature.AttackValue;
    public int DefenseValue => Creature.DefenseValue;
    public int InitiatingValue => Creature.InitiatingValue;
    public string HealthPoints => Creature.DisplayHealthPoints;
    public string PainTolerancePoints => Creature.DisplayPainTolerancePoints;
    public IList<Attack> AttackModes => Creature.AttackModes;
    public int? PoisonResistance => Creature.PoisonResistance;
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

    private bool isSoundAvailable;
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
        if (SelectedAttackMode == null)
        {
            return;
        }

        try
        {
            hitLocation = HitLocationSelector.Get();
            PlaceOfAttack = Lng.Elem(hitLocation.GetDescription());
            LastActionName = $"{Lng.Elem(SelectedAttackMode is MeleeAttack ? "Melee attack" : "Ranged attack")} - {Lng.Elem(SelectedAttackMode.Name)}";
            var (impact, value) = SelectedAttackMode.GetAttack();
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
                        var method = meleeAttack.Weapon.GetType().GetMethod(nameof(meleeAttack.Weapon.GetDamage));
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
                    LastAction = final.ToString();
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
}
