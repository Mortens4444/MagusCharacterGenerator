using Mtf.Helper;
using NUnit.Framework;
using System;
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
				Character = 'c'
			};
			var expectedSerializationContent = $"Byte: 255{Environment.NewLine}Short: -2{Environment.NewLine}UShort: 1{Environment.NewLine}Int32: -1{Environment.NewLine}UInt32: 2{Environment.NewLine}Int64: -100000000000{Environment.NewLine}UInt64: 100000000000{Environment.NewLine}Single: 3,14{Environment.NewLine}Double: 2,71{Environment.NewLine}String: str{Environment.NewLine}Character: c{Environment.NewLine}";
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
			var expectedSerializationContent = $"{{{Environment.NewLine}\t{{ 1, 2, 3}}{Environment.NewLine}\t{{ a, b, c }}{Environment.NewLine}}}{Environment.NewLine}";
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
			var expectedSerializationContent = $"{{{Environment.NewLine}\t{{ 1, 2, 3}}{Environment.NewLine}\t{{ a, b, c }}{Environment.NewLine}}}{Environment.NewLine}";
			TestSerialization(listContainer, expectedSerializationContent);
		}

		private void TestSerialization(object obj, string expectedResult)
		{
			var filePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
			ObjectSerializer.Save(filePath, obj);
			var actualSerializationContent = File.ReadAllText(filePath);
			File.Delete(filePath);
			Assert.AreEqual(expectedResult, actualSerializationContent);
		}
	}
}
