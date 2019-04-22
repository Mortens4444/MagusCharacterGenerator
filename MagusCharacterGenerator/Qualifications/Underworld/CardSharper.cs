﻿using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Underworld
{
    class CardSharper : Qualification
    {
        public CardSharper(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

        public override string ToString() => Lng.Elem("Card sharper");
    }
}
