using Newtonsoft.Json;

namespace M.A.G.U.S.GameSystem;

public class MentalAttack : Attack
{
    public double MinAttacksPerRound { get; init; }

    public double MaxAttacksPerRound { get; init; }

    public int InitiateValue { get; init; }


    [JsonConstructor]
    public MentalAttack() : base() { }

    public MentalAttack(string name, int initiateValue, double minAttacksPerRound = 1, double maxAttacksPerRound = 1)
        : base(name, 0, () => 0)
    {
        MinAttacksPerRound = minAttacksPerRound;
        MaxAttacksPerRound = maxAttacksPerRound;
        InitiateValue = initiateValue;
    }
}
