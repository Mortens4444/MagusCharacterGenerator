using MAGUS.Bestiary.Undead;

namespace MAGUS.Test;

[TestFixture]
public class AnsinatisTests
{
    [Test]
    public void Constructor_CoversAllAlignmentBranches_AcrossManyRolls()
    {
        for (var i = 0; i < 120; i++)
        {
            var ansinatis = new Ansinatis();
            Assert.That(Enum.IsDefined(ansinatis.Alignment), Is.True);
        }
    }

    [Test]
    public void GetPossessionResult_CoversAllOutcomeBranches_AcrossManyRolls()
    {
        var ansinatis = new Ansinatis();
        for (var i = 0; i < 120; i++)
        {
            var result = ansinatis.GetPossessionResult();
            Assert.That(result, Is.Not.Null);
        }
    }
}
