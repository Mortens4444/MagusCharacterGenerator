using MagusCharacterGenerator.Castes.Believer.GodsOfPyarron;
using MagusCharacterGenerator.Castes.Sorcerer;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Races;
using Mtf.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Test
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
			Assert.AreEqual(anonymousClass.Value, deserializedAnonymousClassJson.Value);
			Assert.AreEqual(anonymousClass.Date, deserializedAnonymousClassJson.Date);
			Assert.AreEqual(anonymousClass.Name, deserializedAnonymousClassJson.Name);
			Assert.AreEqual(anonymousClass.Lst, deserializedAnonymousClassJson.Lst);
			Assert.AreEqual(anonymousClass.Lng.ToString(), deserializedAnonymousClassJson.Lng.ToString());
			Assert.AreEqual(anonymousClass.Caste.ToString(), deserializedAnonymousClassJson.Caste.ToString());
			Assert.AreEqual(anonymousClass.Race.ToString(), deserializedAnonymousClassJson.Race.ToString());
			Assert.AreEqual(anonymousClass.Character.ToString(), deserializedAnonymousClassJson.Character.ToString());
		}

		[Test]
		public void SeralizeAndDeserializeCharacter()
		{
			var character = new Character("Mirena", new Human(), new Witch(5));
			var characterJson = ObjectSerializer.GetSerializedString(character);
			var deserializedCharacter = ObjectSerializer.LoadContent<Character>(characterJson);
			Assert.AreEqual(character.Race, deserializedCharacter.Race);
		}

		[Test]
		public void DeserializeCharacter()
		{
			var savedCharacterJson = EmbeddedResourceReader.Get("MagusCharacterGenerator.Test.ObjectDeserializationResults.Character.json");
			var character = ObjectSerializer.LoadContent<Character>(savedCharacterJson);
			Assert.NotNull(character.Castes);
		}
	}
}
