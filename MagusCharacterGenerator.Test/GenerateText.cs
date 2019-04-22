using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceCodeGenerator;
using System;
using System.IO;
using System.Text;

namespace MagusCharacterGenerator.Test
{
    [TestClass]
    public class GenerateText
    {
        [TestMethod]
        public void GenerateTextFile()
        {
            //var imageToText = new ImageToText();
            //var text = imageToText.GetText(@"C:\Users\morte\source\repos\MagusCharacterGenerator\SourceCodeGenerator\Resources\Weapons1.bmp");
            //Console.WriteLine(text);
            //Console.ReadLine();

            var path = @"C:\Users\morte\source\repos\MagusCharacterGenerator\MagusCharacterGenerator\Qualifications";

            var sb = new StringBuilder();
            ForDir(path, sb);
            sb.ToString();
        }

        private void ForDir(string path, StringBuilder sb)
        {
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                ForDir(dir, sb);
            }

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                sb.Append($"  \"{name}\": \"{name}\",");
            }
        }
    }
}
