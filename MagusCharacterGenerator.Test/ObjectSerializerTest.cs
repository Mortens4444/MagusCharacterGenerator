using Mtf.Helper;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace MagusCharacterGenerator.Test
{
	[TestFixture]
	public class ObjectSerializerTest
	{
		[Test]
		public void SerializePrimitives()
		{
			var primitiveContainer = new
			{
				Byte = (byte)255,
				Short = (short)-2,
				UShort = (ushort)1,
				Int32 = (int)-1,
				UInt32 = (uint)2,
				Int64 = (long)-100000000000,
				UInt64 = (ulong)100000000000,
				Single = (float)3.14,
				Double = (double)2.71,
				String = "str",
				Char = 'c'
			};
			var expectedSerializationContent = EmbeddedResourceReader.Get("MagusCharacterGenerator.Test.ObjectSerializationResults.Primitives.json");
			TestSerialization(primitiveContainer, expectedSerializationContent);
		}

		[Test]
		public void SerializeArrays()
		{
			var arrayContainer = new
			{
				Bytes = new byte[] { 1, 2, 3 },
				Strings = new[] { "a", "b", "c" }
			};
			var expectedSerializationContent = EmbeddedResourceReader.Get("MagusCharacterGenerator.Test.ObjectSerializationResults.Arrays.json");
			TestSerialization(arrayContainer, expectedSerializationContent);
		}

		[Test]
		public void SerializeLists()
		{
			var listContainer = new
			{
				Bytes = new List<byte> { 1, 2, 3 },
				Strings = new List<string> { "a", "b", "c" }
			};
			var expectedSerializationContent = EmbeddedResourceReader.Get("MagusCharacterGenerator.Test.ObjectSerializationResults.Lists.json");
			TestSerialization(listContainer, expectedSerializationContent);
		}

		private void TestSerialization(object obj, string expectedResult)
		{
			string actualSerializationContent;
			var filePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
			try
			{
				ObjectSerializer.SaveFile(filePath, obj);
				actualSerializationContent = File.ReadAllText(filePath);
			}
			finally
			{
				File.Delete(filePath);
			}
			Assert.AreEqual(expectedResult, actualSerializationContent);
		}
	}
}
