using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class Flight : SpecialQualification
{
    private readonly DiceThrow diceThrow = new();

    public byte FlightSpeed => (byte)(60 + diceThrow._1K10());
}
