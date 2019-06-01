using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;
using System;

namespace MagusCharacterGenerator.Qualifications
{
	public class Qualification
    {
        public Qualification(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        {
            QualificationLevel = qualificationLevel;
            if (qualificationLevel == QualificationLevel.Base)
            {
                BaseQualificationLevel = level;
            }
            else
            {
                BaseQualificationLevel = level;
                MasterQualificationLevel = level;
            }
        }

        public QualificationLevel QualificationLevel { get; set; }

        public byte BaseQualificationLevel { get; private set; }

        public byte MasterQualificationLevel { get; set; }

		public Type QualificationType => GetType();

		public string ToFullString()
        {
            return ToString() + (QualificationLevel == QualificationLevel.Base ? $" {Lng.Elem("Bl")}" : $" {Lng.Elem("Ml")}");
        }
    }
}
