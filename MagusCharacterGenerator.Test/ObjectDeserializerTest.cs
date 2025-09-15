using M.A.G.U.S.Classes.Believer.GodsOfPyarron;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using NUnit.Framework;

namespace M.A.G.U.S.Test
{
	[TestFixture]
	public class ObjectDeserializerTest
	{
		[Test]
		public void SeralizeAndDeserializeAnonymousClass()
		{
			var anonymousClass = new
			{
				Value = 1,
				Date = DateTime.MaxValue,
				Name = "Anuman",
				Lst = new List<byte> { 1, 2, 3 },
				Lng = new LanguageKnowledge(Language.Kranich, 3),
				Caste = new ArelPriest(1),
				Race = new Orc(),
				Character = new Character("Anuman", new Amund(), new ArelPriest(1))
			};
			var anonymousClassJson = ObjectSerializer.GetSerializedString(anonymousClass);
			var deserializedAnonymousClassJson = ObjectSerializer.LoadContent<dynamic>(anonymousClassJson);
			Assert.That(anonymousClass.Value, Is.EqualTo(deserializedAnonymousClassJson.Value));
			Assert.That(anonymousClass.Date, Is.EqualTo(deserializedAnonymousClassJson.Date));
			Assert.That(anonymousClass.Name, Is.EqualTo(deserializedAnonymousClassJson.Name));
			Assert.That(anonymousClass.Lst, Is.EqualTo(deserializedAnonymousClassJson.Lst));
			Assert.That(anonymousClass.Lng.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Lng.ToString()));
			Assert.That(anonymousClass.Caste.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Caste.ToString()));
			Assert.That(anonymousClass.Race.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Race.ToString()));
			Assert.That(anonymousClass.Character.ToString(), Is.EqualTo(deserializedAnonymousClassJson.Character.ToString()));
		}

		[Test]
		public void SerializeAndDeserializeCharacter()
		{
			var character = new Character("Mirena", new Human(), new Witch(5));
			var characterJson = ObjectSerializer.GetSerializedString(character);
			var deserializedCharacter = ObjectSerializer.LoadContent<Character>(characterJson);
			Assert.That(character.Race.ToString(), Is.EqualTo(deserializedCharacter.Race.ToString()));
		}

		[Test]
		public void DeserializeCharacter()
		{
			var savedCharacterJson = EmbeddedResourceReader.Get("M.A.G.U.S.Test.ObjectDeserializationResults.Character.json");
			var character = ObjectSerializer.LoadContent<Character>(savedCharacterJson);
			Assert.That(character.Castes, Is.Not.Null);
		}
	}
}
