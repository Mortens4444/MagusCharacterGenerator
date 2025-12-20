using M.A.G.U.S.Enums;
using Mtf.Extensions.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace M.A.G.U.S.GameSystem;

public abstract class Attacker
{
    private readonly DiceThrow diceThrow = new();
    private string name;

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }

    public virtual int InitiateValue { get; set; }

    public virtual int AttackValue { get; set; }

    public virtual int DefenseValue { get; set; }

    public virtual int AimValue { get; set; }

    public double AttacksPerRound { get; protected set; } = 1;

    public AttackStrategy AttackStrategy { get; } = AttackStrategy.AttackFirst;

    public abstract List<Attack> AttackModes { get; protected set; }

    public int RollInitiative()
    {
        return diceThrow._1D10();
    }

    public int RollAttack()
    {
        return diceThrow._1D100();
    }

    public abstract int GetDamage();

    public Attack GetRandomAttackMode()
    {
        if (AttackModes == null || AttackModes.Count == 0)
        {
            throw new InvalidOperationException("No attack modes available.");
        }

        int randomIndex = RandomProvider.GetSecureRandomInt(0, AttackModes.Count);
        return AttackModes[randomIndex];
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
