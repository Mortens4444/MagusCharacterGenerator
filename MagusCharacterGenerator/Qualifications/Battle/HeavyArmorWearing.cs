﻿using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Battle
{
    class HeavyArmorWearing : Qualification
    {
        public HeavyArmorWearing(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

        public override string ToString() => Lng.Elem("Heavy armor wearing");
    }
}
