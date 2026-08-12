using MAGUS.Enums;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

public class Wier : Race
{
    public override int Beauty => 1;

    public override int Intelligence => 1;

    public override Alignment? Alignment => Enums.Alignment.Death;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(30),
        new KeenHearing(2),
        new KeenSmell(2)
    ];
}
