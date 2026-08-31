using MAGUS.Utils;

namespace MAGUS.Test;

[TestFixture]
public class ObjectSerializerOverwriteTests
{
    [Test]
    public void SaveFile_OverwritingWithShorterContent_DoesNotLeaveTrailingGarbage()
    {
        var path = Path.Combine(Path.GetTempPath(), $"magus-test-{Guid.NewGuid()}.json");
        try
        {
            ObjectSerializer.SaveFile(path, new { Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" });
            ObjectSerializer.SaveFile(path, new { Name = "B" });

            var content = File.ReadAllText(path);
            Assert.DoesNotThrow(() => Newtonsoft.Json.Linq.JObject.Parse(content), $"File content is not valid JSON: {content}");
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
