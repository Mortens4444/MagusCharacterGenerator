using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CreatureDetailsViewModel : ObservableObject
{
    public Creature Creature { get; init; }

    public ICommand InitiateCommand { get; }
    public ICommand AttackCommand { get; }
    public ICommand RollDamageCommand { get; }

    public CreatureDetailsViewModel() { }

    public CreatureDetailsViewModel(Creature creature)
    {
        Creature = creature ?? throw new ArgumentNullException(nameof(creature));
        NumberAppearing = creature.GetNumberAppearing();
        InitiateCommand = new Command(OnInitiate);
        AttackCommand = new Command(OnAttack);
        RollDamageCommand = new Command(OnRollDamage);
        LastAction = String.Empty;
    }

    public string Occurrence => Creature.Occurrence.ToString();
    public string Intelligence => Creature.Intelligence.ToString();
    public Enums.Size Size => Creature.Size;
    public int Speed => Creature.Speed;
    public int AttackValue => Creature.AttackValue;
    public int DefenseValue => Creature.DefenseValue;
    public int InitiatingValue => Creature.InitiatingValue;
    public int MaxHealthPoints => Creature.MaxHealthPoints;
    public int HealthPoints => Creature.HealthPoints;
    public int MaxPainTolerancePoints => Creature.MaxPainTolerancePoints;
    public int PainTolerancePoints => Creature.PainTolerancePoints;
    public byte? PoisonResistance => Creature.PoisonResistance;
    public uint ExperiencePoints => Creature.ExperiencePoints;
    public double AttacksPerRound => Creature.AttacksPerRound;

    private int numberAppearing;
    public int NumberAppearing
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
            var final = (byte)(hitLocation == Enums.PlaceOfAttack.Head ? dmg * 2 : dmg);
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
