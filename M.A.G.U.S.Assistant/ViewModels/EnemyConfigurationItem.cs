using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class EnemyConfigurationItem : ObservableObject
{
    private readonly Creature template;
    private int distance;
    private int actualHealthPoints;
    private int? actualPainTolerancePoints;
    private string name;
    private AttackStrategy strategy;
    private AttackDirection direction;
    private Attack? selectedAttackMode;

    public EnemyConfigurationItem(Creature template, int index)
    {
        this.template = template;
        name = $"{Lng.Elem(template.Name)} #{index + 1}";
        Strategy = AttackStrategy.AttackRandom;
        Distance = 10;

        MinHp = template.MinHealthPoints ?? template.HealthPoints ?? 1;
        MaxHp = template.MaxHealthPoints ?? template.HealthPoints ?? 100;
        if (MinHp > MaxHp)
        {
            MinHp = MaxHp;
        }

        ActualHealthPoints = RandomProvider.GetSecureRandomInt(MinHp, MaxHp + 1);

        if (template.PainTolerancePoints == null &&
            template.MinPainTolerancePoints == null &&
            template.MaxPainTolerancePoints == null)
        {
            ActualPainTolerancePoints = null;
            MinPtp = 0;
            MaxPtp = 0;
        }
        else
        {
            MinPtp = template.MinPainTolerancePoints
                     ?? template.PainTolerancePoints
                     ?? 1;

            MaxPtp = template.MaxPainTolerancePoints
                     ?? template.PainTolerancePoints
                     ?? MinPtp;

            if (MinPtp > MaxPtp)
            {
                MinPtp = MaxPtp;
            }

            ActualPainTolerancePoints =
                RandomProvider.GetSecureRandomInt(MinPtp, MaxPtp + 1);
        }
        AvailableAttackModes.Add(null);
        if (template.AttackModes != null)
        {
            AvailableAttackModes.AddRange(template.AttackModes);
        }
    }

    public IList<AttackDirection> AttackDirections { get; } = [.. Enum.GetValues<AttackDirection>()];
    public IList<AttackStrategy> AttackStrategies { get; } = [.. Enum.GetValues<AttackStrategy>()];
    public bool HasPainTolerance => ActualPainTolerancePoints.HasValue;

    public string Name
    {
        get => name;
        set => SetProperty(ref name, value);
    }

    public int Distance
    {
        get => distance;
        set => SetProperty(ref distance, value);
    }

    public int ActualHealthPoints
    {
        get => actualHealthPoints;
        set => SetProperty(ref actualHealthPoints, value);
    }

    public int? ActualPainTolerancePoints
    {
        get => actualPainTolerancePoints;
        set
        {
            if (SetProperty(ref actualPainTolerancePoints, value))
            {
                OnPropertyChanged(nameof(HasPainTolerance));
            }
        }
    }

    public AttackStrategy Strategy
    {
        get => strategy;
        set => SetProperty(ref strategy, value);
    }

    public AttackDirection Direction
    {
        get => direction;
        set => SetProperty(ref direction, value);
    }

    public Attack? SelectedAttackMode
    {
        get => selectedAttackMode;
        set => SetProperty(ref selectedAttackMode, value);
    }

    public int MinHp { get; }
    public int MaxHp { get; }
    public bool HasHpRange => MaxHp > MinHp;

    public int MinPtp { get; }
    public int MaxPtp { get; }
    public bool HasPtpRange => MaxPtp > MinPtp;

    public List<Attack?> AvailableAttackModes { get; } = [];

    public Creature CreateInstance()
    {
        var instance = (Creature)Activator.CreateInstance(template.GetType())!;
        instance.Name = Name;
        instance.ActualHealthPoints = ActualHealthPoints;
        instance.HealthPoints = ActualHealthPoints;
        instance.ActualPainTolerancePoints = ActualPainTolerancePoints;
        instance.PainTolerancePoints = ActualPainTolerancePoints;
        return instance;
    }
}