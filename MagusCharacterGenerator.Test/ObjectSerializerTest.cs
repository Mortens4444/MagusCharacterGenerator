using M.A.G.U.S.Utils;
using NUnit.Framework;

namespace M.A.G.U.S.Test
{
	[TestFixture]
	public class ObjectSerializerTest
	{
		[Test]
		public void SerializePrimitives()
		{
			TestSerialization(new
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
				},
				"M.A.G.U.S.Test.ObjectSerializationResults.Primitives.json");
		}

		[Test]
		public void SerializeArrays()
		{
			TestSerialization(new
				{
					Bytes = new byte[] { 1, 2, 3 },
					Strings = new[] { "a", "b", "c" }
				},
				"M.A.G.U.S.Test.ObjectSerializationResults.Arrays.json");
		}

		[Test]
		public void SerializeLists()
		{
			TestSerialization(new
				{
					Bytes = new List<byte> { 1, 2, 3 },
					Strings = new List<string> { "a", "b", "c" }
				},
				"M.A.G.U.S.Test.ObjectSerializationResults.Lists.json");
		}

		private void TestSerialization(object obj, string serializationResultFileName)
		{
			var expectedSerializationContent = EmbeddedResourceReader.Get(serializationResultFileName);
			var actualSerializationContent = ObjectSerializer.GetSerializedString(obj);
			Assert.That(expectedSerializationContent, Is.EqualTo(actualSerializationContent));
		}
	}
}
