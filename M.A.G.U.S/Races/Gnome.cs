using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

/// <summary>
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B3dexe-r61/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/gn%C3%B3m-r69/
/// </summary>
public class Gnome : Race
{
    public override short Strength => -1;

    public override short Dexterity => 1;

    public override short Intelligence => 1;

    public override QualificationList Qualifications =>
    [
        new Cartography(),
        new Craft(Profession.Goldsmith)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new Infravision(25)
    ];
}
