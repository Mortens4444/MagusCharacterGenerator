using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    public bool CanUpgrade => BaseClass.CanUpgrade;

    public int PendingLevelUps
    {
        get
        {
            var targetLevel = BaseClass.GetLevelByExperiencePoints(BaseClass.ExperiencePoints);
            return Math.Max(0, targetLevel - BaseClass.Level);
        }
    }

    public ulong ExperiencePoints
    {
        get => BaseClass.ExperiencePoints;
        set
        {
            if (BaseClass.ExperiencePoints != value)
            {
                BaseClass.ExperiencePoints = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Level));
                OnPropertyChanged(nameof(PendingLevelUps));
                OnPropertyChanged(nameof(CanUpgrade));

                if (BaseClass.CanUpgrade)
                {
                    LevelUpAvailable?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    public int Level
    {
        get => BaseClass.Level;
        set
        {
            if (BaseClass.Level != value)
            {
                BaseClass.Level = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanUpgrade));
                OnPropertyChanged(nameof(PendingLevelUps));
            }
        }
    }

    public event EventHandler? LevelUpAvailable;

    public event Action<int>? LevelUpApplied;

    public void ApplyLevelUp(int painToleranceIncrease, int manaIncrease)
    {
        Level++;

        MaxPainTolerancePoints += painToleranceIncrease;
        MaxManaPoints += manaIncrease;
        MaxPsiPoints += PsiPointsModifier;
        QualificationPoints += BaseClass.QualificationPointsModifier;
        TotalCombatValueModifier += CombatValueModifierPerLevel;

        OnPropertyChanged(nameof(Level));
        OnPropertyChanged(nameof(QualificationPoints));
        OnPropertyChanged(nameof(RemainingCombatValueModifier));
        OnPropertyChanged(nameof(MaxHealthPoints));
        OnPropertyChanged(nameof(MaxPainTolerancePoints));
        OnPropertyChanged(nameof(MaxManaPoints));
        OnPropertyChanged(nameof(MaxPsiPoints));
    }

    public void AddExperience(ulong amount)
    {
        if (amount == 0)
        {
            return;
        }

        var oldPending = PendingLevelUps;
        ExperiencePoints = checked(ExperiencePoints + amount);

        var newPending = PendingLevelUps;
        if (newPending > oldPending)
        {
            LevelUpAvailable?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool ApplyNextLevelUp(Action<IClass>? allocateModifiers = null)
    {
        var pending = PendingLevelUps;
        if (pending <= 0)
        {
            return false;
        }

        var targetLevel = BaseClass.Level + 1;
        Level = targetLevel;

        try
        {
            allocateModifiers?.Invoke(BaseClass);
        }
        catch
        {
            throw;
        }
        finally
        {
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(CanUpgrade));
            OnPropertyChanged(nameof(PendingLevelUps));
        }

        LevelUpApplied?.Invoke(targetLevel);
        return true;
    }

    public int ApplyAllPendingLevelUps(Action<IClass>? allocatePerLevel = null)
    {
        var applied = 0;
        while (PendingLevelUps > 0)
        {
            var newLevel = BaseClass.Level + 1;
            Level = newLevel;

            try
            {
                allocatePerLevel?.Invoke(BaseClass);
            }
            catch
            {
                throw;
            }
            finally
            {
                applied++;
                OnPropertyChanged(nameof(Level));
                OnPropertyChanged(nameof(CanUpgrade));
                OnPropertyChanged(nameof(PendingLevelUps));
                LevelUpApplied?.Invoke(newLevel);
            }
        }

        return applied;
    }
}