using MAGUS.GameSystem;
using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class Flight : SpecialQualification
{
    private readonly DiceThrow diceThrow = new();

    public int FlightSpeed => 60 + diceThrow._1D10();
}
