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
				Char = 'c'
			};
			var expectedSerializationContent = $"{{{Environment.NewLine}\tByte: 255{Environment.NewLine}\tShort: -2{Environment.NewLine}\tUShort: 1{Environment.NewLine}\tInt32: -1{Environment.NewLine}\tUInt32: 2{Environment.NewLine}\tInt64: -100000000000{Environment.NewLine}\tUInt64: 100000000000{Environment.NewLine}\tSingle: 3,14{Environment.NewLine}\tDouble: 2,71{Environment.NewLine}\tString: \"str\"{Environment.NewLine}\tChar: 'c'{Environment.NewLine}}}{Environment.NewLine}";
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
			var expectedSerializationContent = $"{{{Environment.NewLine}\tBytes: Array{Environment.NewLine}\t{{{Environment.NewLine}\t\t1, 2, 3{Environment.NewLine}\t}}{Environment.NewLine}\tStrings: Array{Environment.NewLine}\t{{{Environment.NewLine}\t\t\"a\", \"b\", \"c\"{Environment.NewLine}\t}}{Environment.NewLine}}}{Environment.NewLine}";
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
			var expectedSerializationContent = $"{{{Environment.NewLine}\tBytes: List{Environment.NewLine}\t{{{Environment.NewLine}\t\t1, 2, 3{Environment.NewLine}\t}}{Environment.NewLine}\tStrings: List{Environment.NewLine}\t{{{Environment.NewLine}\t\t\"a\", \"b\", \"c\"{Environment.NewLine}\t}}{Environment.NewLine}}}{Environment.NewLine}";
			TestSerialization(listContainer, expectedSerializationContent);
		}

		private void TestSerialization(object obj, string expectedResult)
		{
			string actualSerializationContent;
			var filePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
			try
			{
				ObjectSerializer.Save(filePath, obj);
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
