﻿using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class HalfElf : Race, IUseRangedWeapons
{
    public override short Strength => -1;

    public override short Speed => 1;

    public override QualificationList Qualifications =>
    [
        new Riding(QualificationLevel.Master),
        new DressageTraining(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new BetterHearing(1.5),
        new BetterSeeing(2),
        new GoodRunner(),
        new Infravision(10),
        new ResistanceToNecromantia(-6),
        new GoodArcher(10)
    ];

    public override string Name => "Half-elf";
}
