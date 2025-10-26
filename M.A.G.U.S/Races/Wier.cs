﻿using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Wier : Race
{
    public override sbyte Beauty => 1;

    public override sbyte Intelligence => 1;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(30),
        new KeenHearing(2),
        new KeenSmell(2)
    ];
}
