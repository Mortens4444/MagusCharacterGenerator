using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Storyteller
{
	static class PictureBoxExtensions
    {
        public static void LoadImage(this PictureBox pictureBox, string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (var sourceImage = Image.FromFile(path))
                    {
						pictureBox.Image = (Bitmap)sourceImage.Clone();
                    }
                }
                catch { }
            }
        }
    }
}
