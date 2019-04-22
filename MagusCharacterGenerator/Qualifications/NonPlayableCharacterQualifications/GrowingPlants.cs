﻿using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Scientific
{
    class GrowingPlants : Qualification
    {
        public GrowingPlants(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

        public override string ToString() => Lng.Elem("Growing plants");
    }
}
