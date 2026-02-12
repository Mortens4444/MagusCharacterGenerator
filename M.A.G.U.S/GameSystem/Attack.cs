using M.A.G.U.S.Enums;
using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

public abstract class Attack
{
    public string Name { get; set; }

    public int Value { get; set; }

    [JsonIgnore]
    public Func<int> GetDamage { get; set; }

    [JsonConstructor]
    protected Attack() { }

    public Attack(string name, int value, Func<int> getDamageCallback)
    {
        Name = name;
        Value = value;
        GetDamage = getDamageCallback;
    }

    public (AttackImpact impact, int value) GetAttack()
    {
        var diceThrow = new DiceThrow();
        var roll = diceThrow._1D100();
        var impact = roll == 100 ? AttackImpact.CriticalDamage : roll == 1 ? AttackImpact.FatalMistake : AttackImpact.Normal;
        return (impact, Value + roll);
    }
}
