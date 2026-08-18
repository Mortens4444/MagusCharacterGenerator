using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;

namespace MAGUS.Test;

[TestFixture]
public class QualificationListBehaviorTests
{
    [Test]
    public void UpgradeOrAddQualification_AddsNewQualification()
    {
        var list = new QualificationList();
        list.UpgradeOrAddQualification(new Riding());
        Assert.That(list, Has.Count.EqualTo(1));
    }

    [Test]
    public void UpgradeOrAddQualification_UpgradesExistingBaseToMaster()
    {
        var list = new QualificationList { new Riding(QualificationLevel.Base) };
        list.UpgradeOrAddQualification(new Riding(QualificationLevel.Master));

        Assert.That(list.Single().QualificationLevel, Is.EqualTo(QualificationLevel.Master));
    }

    [Test]
    public void Add_SameQualificationTwice_KeepsHigherLevel()
    {
        var list = new QualificationList
        {
            new Riding(QualificationLevel.Base)
        };
        list.Add(new Riding(QualificationLevel.Master));

        Assert.That(list, Has.Count.EqualTo(1));
        Assert.That(list.Single().QualificationLevel, Is.EqualTo(QualificationLevel.Master));
    }

    [Test]
    public void Add_LowerLevelAfterHigher_IsIgnored()
    {
        var list = new QualificationList
        {
            new Riding(QualificationLevel.Master)
        };
        list.Add(new Riding(QualificationLevel.Base));

        Assert.That(list.Single().QualificationLevel, Is.EqualTo(QualificationLevel.Master));
    }

    [Test]
    public void Insert_AtIndex_ReplacesLowerLevelEntry()
    {
        var list = new QualificationList
        {
            new Riding(QualificationLevel.Base)
        };
        list.Insert(0, new Riding(QualificationLevel.Master));

        Assert.That(list, Has.Count.EqualTo(1));
    }

    [Test]
    public void InsertRange_AddsAllQualifications()
    {
        var list = new QualificationList();
        list.InsertRange(0, [new Riding(), new Swimming()]);
        Assert.That(list, Has.Count.EqualTo(2));
    }
}
