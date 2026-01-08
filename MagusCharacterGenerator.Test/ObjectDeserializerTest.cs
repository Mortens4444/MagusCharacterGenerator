using M.A.G.U.S.Classes.Believer.GodsOfPyarron;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.Test
{
	[TestFixture]
	public class ObjectDeserializerTest
	{
		[Test]
		public void SeralizeAndDeserializeAnonymousClass()
        {
            var anonymousClass = new TestDto
            {
                Value = 1,
                Date = DateTime.MaxValue,
                Name = "Anuman",
                Lst = new List<int> { 1, 2, 3 },
                Lng = new LanguageLore(Language.Krannish, 3),
                Class = new ArelPriest(1, true),
                Race = new Orc(),
                Character = new Character(new Settings(false), "Anuman", new Amund(), ClassCreator.GetClass(typeof(ArelPriest), 1))
            };
            var anonymousClassJson = ObjectSerializer.GetSerializedString(anonymousClass);
            var deserializedAnonymousClassJson = ObjectSerializer.LoadContent<TestDto>(anonymousClassJson);
            Assert.That(anonymousClass.Value, Is.EqualTo(deserializedAnonymousClassJson.Value));
            Assert.That(anonymousClass.Date, Is.EqualTo(deserializedAnonymousClassJson.Date));
            Assert.That(anonymousClass.Name, Is.EqualTo(deserializedAnonymousClassJson.Name));
            Assert.That(anonymousClass.Lst, Is.EqualTo(deserializedAnonymousClassJson.Lst));
            Assert.That(anonymousClass.Lng.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Lng.ToString()));
            Assert.That(anonymousClass.Class.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Class.ToString()));
            Assert.That(anonymousClass.Race.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Race.ToString()));
            Assert.That(anonymousClass.Character.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Character.ToString()));
        }

        [Test]
		public void SerializeAndDeserializeCharacter()
		{
			var character = new Character(new Settings(false), "Mirena", new Human(), ClassCreator.GetClass(typeof(Witch), 5));
			var characterJson = ObjectSerializer.GetSerializedString(character);
			var deserializedCharacter = ObjectSerializer.LoadContent<Character>(characterJson);
			Assert.That(character.Race.ToString(), Is.EqualTo(deserializedCharacter.Race.ToString()));
		}

		[Test]
		public void DeserializeCharacter()
		{
			var savedCharacterJson = EmbeddedResourceReader.Get("M.A.G.U.S.Test.ObjectDeserializationResults.Character.json", typeof(ObjectDeserializerTest).Assembly);
			var character = ObjectSerializer.LoadContent<Character>(savedCharacterJson);
			Assert.That(character.Classes, Is.Not.Null);
		}
    }
}
