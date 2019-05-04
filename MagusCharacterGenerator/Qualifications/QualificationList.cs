using MagusCharacterGenerator.GameSystem.Qualifications;
using System.Collections.Generic;
using System.Linq;

namespace MagusCharacterGenerator.Qualifications
{
	public class QualificationList : List<Qualification>
    {
        public void UpgradeOrAddQualification(Qualification newMasterQualification)
        {
            // WeaponUsage, WeaponThrow should be handled => Or main weapons should be listed first!
            var firstBaseQualification = this.FirstOrDefault(
                qualification => qualification.GetType().Equals(newMasterQualification.GetType())
                && qualification.QualificationLevel == QualificationLevel.Base);
            if (firstBaseQualification != null)
            {
                firstBaseQualification.QualificationLevel = QualificationLevel.Master;
                firstBaseQualification.MasterQualificationLevel = newMasterQualification.MasterQualificationLevel;
            }
            else
            {
				if (newMasterQualification is ICanHaveMany)
				{
					Add(newMasterQualification);
				}
				else
				{
					var sameQualification = this.FirstOrDefault(q => q.GetType() == newMasterQualification.GetType());
					if (sameQualification != null)
					{
						if (sameQualification.QualificationLevel == QualificationLevel.Base && newMasterQualification.QualificationLevel == QualificationLevel.Master)
						{
							sameQualification.QualificationLevel = QualificationLevel.Master;
						}
					}
					else
					{
						Add(newMasterQualification);
					}
				}
            }
        }

        //public void BuyQualificationUpgrade(Qualification qualification)
        //{
        //    Add(qualification);
        //}

        //public void BuyNewQualification(Qualification qualification)
        //{
        //    base.Add(qualification);
        //}

        //public new void Add(Qualification qualification)
        //{
        //    SetQualificationLevel(qualification);
        //    base.Add(qualification);
        //}

        //public new void AddRange(IEnumerable<Qualification> qualifications)
        //{
        //    SetQualificationLevel(qualifications.ToArray());
        //    base.AddRange(qualifications);
        //}

        //public new void Insert(int index, Qualification qualification)
        //{
        //    SetQualificationLevel(qualification);
        //    base.Insert(index, qualification);
        //}

        //public new void InsertRange(int index, IEnumerable<Qualification> qualifications)
        //{
        //    SetQualificationLevel(qualifications.ToArray());
        //    base.InsertRange(index, qualifications);
        //}

        //private static void SetQualificationLevel(params Qualification[] qualifications)
        //{
        //    foreach (var qualification in qualifications)
        //    {
        //        switch (qualification.QualificationLevel)
        //        {
        //            case QualificationLevel.Master:
        //                var q = this.FirstOrDefault(qualification => qualification);
        //                if (q != null)
        //                {
        //                }

        //                qualification.MasterQualificationLevel =
        //                break;
        //            case QualificationLevel.Base:
        //                break;
        //        }

        //    }
        //}
    }
}
