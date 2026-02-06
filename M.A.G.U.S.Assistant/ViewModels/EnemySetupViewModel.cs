using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using Mtf.Extensions.Services;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class EnemySetupViewModel : ObservableObject
{
    private readonly Creature templateEnemy;
    private int enemyCountMin = 1;
    private int enemyCountMax = 1;
    private int enemyCount = 1;
    private int globalHealthPoints;
    private int? globalPainTolerancePoints;
    private int globalDistance = 10;
    private AttackDirection globalDirection;
    private AttackStrategy globalStrategy;
    private int globalHpMin;
    private int globalHpMax;
    private bool hasGlobalHpRange;
    private int globalPtpMin;
    private int globalPtpMax;
    private bool hasGlobalPtpRange;

    public event Action<List<EnemyConfigurationItem>>? OnEnemiesConfirmed;
    public event Action? OnCancel;

    public int EnemyCountMin
    {
        get => enemyCountMin;
        set => SetProperty(ref enemyCountMin, value);
    }

    public int EnemyCountMax
    {
        get => enemyCountMax;
        set => SetProperty(ref enemyCountMax, value);
    }

    public int EnemyCount
    {
        get => enemyCount;
        set
        {
            if (SetProperty(ref enemyCount, value))
            {
                UpdateConfigs();
            }
        }
    }

    public int GlobalHealthPoints
    {
        get => globalHealthPoints;
        set => SetProperty(ref globalHealthPoints, value);
    }

    public int? GlobalPainTolerancePoints
    {
        get => globalPainTolerancePoints;
        set => SetProperty(ref globalPainTolerancePoints, value);
    }

    public int GlobalDistance
    {
        get => globalDistance;
        set => SetProperty(ref globalDistance, value);
    }

    public AttackDirection GlobalDirection
    {
        get => globalDirection;
        set => SetProperty(ref globalDirection, value);
    }

    public AttackStrategy GlobalStrategy
    {
        get => globalStrategy;
        set => SetProperty(ref globalStrategy, value);
    }

    public int GlobalHpMin
    {
        get => globalHpMin;
        set => SetProperty(ref globalHpMin, value);
    }

    public int GlobalHpMax
    {
        get => globalHpMax;
        set => SetProperty(ref globalHpMax, value);
    }

    public bool HasGlobalHpRange
    {
        get => hasGlobalHpRange;
        set => SetProperty(ref hasGlobalHpRange, value);
    }

    public int GlobalPtpMin
    {
        get => globalPtpMin;
        set => SetProperty(ref globalPtpMin, value);
    }

    public int GlobalPtpMax
    {
        get => globalPtpMax;
        set => SetProperty(ref globalPtpMax, value);
    }

    public bool HasGlobalPtpRange
    {
        get => hasGlobalPtpRange;
        set => SetProperty(ref hasGlobalPtpRange, value);
    }

    public ObservableCollection<EnemyConfigurationItem> ConfigItems { get; } = [];
    public IList<AttackDirection> GlobalAttackDirections { get; } = [.. Enum.GetValues<AttackDirection>()];
    public IList<AttackStrategy> GlobalAttackStrategies { get; } = [.. Enum.GetValues<AttackStrategy>()];

    public EnemySetupViewModel(Creature selectedEnemy)
    {
        templateEnemy = selectedEnemy;
        UpdateConfigs();
        globalHealthPoints = selectedEnemy.HealthPoints ?? 1;
        globalPainTolerancePoints = selectedEnemy.PainTolerancePoints;

        var range = templateEnemy.GetNumberAppearingRange();
        if (range != null)
        {
            EnemyCountMin = range.Value.Min;
            EnemyCountMax = range.Value.Max;
            EnemyCount = RandomProvider.GetSecureRandomInt(EnemyCountMin, EnemyCountMax + 1);
        }
        if (selectedEnemy.MinHealthPoints.HasValue && selectedEnemy.MaxHealthPoints.HasValue)
        {
            GlobalHpMin = selectedEnemy.MinHealthPoints.Value;
            GlobalHpMax = selectedEnemy.MaxHealthPoints.Value;
            HasGlobalHpRange = GlobalHpMin != GlobalHpMax;
            GlobalHealthPoints = GlobalHpMin;
        }
        else
        {
            GlobalHpMin = GlobalHpMax = selectedEnemy.HealthPoints ?? 1;
            HasGlobalHpRange = false;
            GlobalHealthPoints = GlobalHpMin;
        }

        if (selectedEnemy.MinPainTolerancePoints.HasValue &&
            selectedEnemy.MaxPainTolerancePoints.HasValue)
        {
            GlobalPtpMin = selectedEnemy.MinPainTolerancePoints.Value;
            GlobalPtpMax = selectedEnemy.MaxPainTolerancePoints.Value;
            HasGlobalPtpRange = GlobalPtpMin != GlobalPtpMax;
            GlobalPainTolerancePoints = GlobalPtpMin;
        }
        else
        {
            GlobalPtpMin = GlobalPtpMax = selectedEnemy.PainTolerancePoints ?? 0;
            HasGlobalPtpRange = false;
            GlobalPainTolerancePoints = selectedEnemy.PainTolerancePoints;
        }

        GlobalDirection = AttackDirection.Front;
        GlobalStrategy = AttackStrategy.AttackRandom;
    }

    private void UpdateConfigs()
    {
        // Ha növeljük a számot
        while (ConfigItems.Count < EnemyCount)
        {
            var newItem = new EnemyConfigurationItem(templateEnemy, ConfigItems.Count);
            // Alkalmazzuk a jelenlegi globális beállításokat az újra is
            newItem.Distance = GlobalDistance;
            newItem.Direction = GlobalDirection;
            newItem.Strategy = GlobalStrategy;
            ConfigItems.Add(newItem);
        }

        // Ha csökkentjük a számot
        while (ConfigItems.Count > EnemyCount)
        {
            ConfigItems.RemoveAt(ConfigItems.Count - 1);
        }
    }

    [RelayCommand]
    private void ApplyDistanceToAll()
    {
        foreach (var item in ConfigItems) item.Distance = GlobalDistance;
    }

    [RelayCommand]
    private void ApplyDirectionToAll()
    {
        foreach (var item in ConfigItems) item.Direction = GlobalDirection;
    }

    [RelayCommand]
    private void ApplyStrategyToAll()
    {
        foreach (var item in ConfigItems) item.Strategy = GlobalStrategy;
    }

    [RelayCommand]
    private void ApplyHealthPointsToAll()
    {
        foreach (var item in ConfigItems)
        {
            item.ActualHealthPoints = Math.Clamp(
                GlobalHealthPoints,
                item.MinHp,
                item.MaxHp);
        }
    }

    [RelayCommand]
    private void ApplyPainTolerancePointsToAll()
    {
        if (GlobalPainTolerancePoints == null)
        {
            foreach (var item in ConfigItems)
            {
                item.ActualPainTolerancePoints = null;
            }

            return;
        }

        foreach (var item in ConfigItems.Where(i => i.HasPainTolerance))
        {
            item.ActualPainTolerancePoints = Math.Clamp(
                GlobalPainTolerancePoints.Value,
                item.MinPtp,
                item.MaxPtp);
        }
    }


    [RelayCommand]
    private void AddEnemies()
    {
        OnEnemiesConfirmed?.Invoke(ConfigItems.ToList());
    }

    [RelayCommand]
    private void Cancel()
    {
        OnCancel?.Invoke();
    }

    [RelayCommand]
    private void RandomizeEnemyCount()
    {
        EnemyCount = templateEnemy.GetNumberAppearing();
    }
}