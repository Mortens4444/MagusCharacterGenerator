using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class CreatureDetailsViewModel : ObservableObject
{
    private readonly Creature creature;

    public ICommand InitiateCommand { get; }
    public ICommand AttackCommand { get; }
    public ICommand RollDamageCommand { get; }

    public CreatureDetailsViewModel() { }

    public CreatureDetailsViewModel(Creature creature)
    {
        this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
        NumberAppearing = creature.GetNumberAppearing();
        InitiateCommand = new Command(OnInitiate);
        AttackCommand = new Command(OnAttack);
        RollDamageCommand = new Command(OnRollDamage);
        LastAction = String.Empty;
    }

    public string Occurrence => creature.Occurrence.ToString();
    public string Intelligence => creature.Intelligence.ToString();
    public string Size => creature.Size.ToString();
    public int Speed => creature.Speed;
    public int AttackValue => creature.AttackValue;
    public int DefenseValue => creature.DefenseValue;
    public int InitiatingValue => creature.InitiatingValue;
    public int MaxHealthPoints => creature.MaxHealthPoints;
    public int HealthPoints => creature.HealthPoints;
    public int MaxPainTolerancePoints => creature.MaxPainTolerancePoints;
    public int PainTolerancePoints => creature.PainTolerancePoints;
    public byte? PoisonResistance => creature.PoisonResistance;
    public uint ExperiencePoints => creature.ExperiencePoints;
    public double AttacksPerRound => creature.AttacksPerRound;

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
            LastAction = creature.GetInitiate().ToString();
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
            var (impact, value) = creature.GetAttack();
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
            var dmg = creature.GetDamage();
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
