﻿using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B3dexe-r61/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// </summary>
public class CourtGoblin : Race
{
    public override sbyte Strength => -2;

    public override sbyte Stamina => 1;

    public override sbyte Intelligence => -1;

    public override sbyte Health => 1;

    public override sbyte Beauty => -2;

    public override sbyte Astral => -2;

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(20),
        new UndergroundMasters(5),
        new KeenSmell(3)
    ];

    public override string Name => "Court goblin";
}
