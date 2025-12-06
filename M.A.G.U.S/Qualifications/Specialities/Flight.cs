using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class Flight : SpecialQualification
{
    private readonly DiceThrow diceThrow = new();

    public int FlightSpeed => 60 + diceThrow._1D10();
}
