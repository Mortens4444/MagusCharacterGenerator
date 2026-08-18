using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Races;
using MAGUS.Utils;

namespace MAGUS.Test;

[TestFixture]
public class ObjectSerializerFileTests
{
    private static TestDto CreateDto(string name) => new()
    {
        Name = name,
        Lst = [1, 2, 3],
        Class = new Craftsman(),
        Race = new Human(),
    };

    [Test]
    public void SaveFile_ThenLoadFile_RoundTripsContent()
    {
        var path = Path.Combine(Path.GetTempPath(), $"magus-test-{Guid.NewGuid()}.json");
        try
        {
            var dto = CreateDto("Alice");

            ObjectSerializer.SaveFile(path, dto);
            var loaded = ObjectSerializer.LoadFile<TestDto>(path);

            Assert.That(loaded.Name, Is.EqualTo(dto.Name));
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

    [Test]
    public void GetSerializedString_ProducesJson()
    {
        var json = ObjectSerializer.GetSerializedString(CreateDto("Bob"));
        Assert.That(json, Does.Contain("Bob"));
    }
}
