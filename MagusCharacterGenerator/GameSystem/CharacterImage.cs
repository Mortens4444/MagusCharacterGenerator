using System.Drawing;
using System.Windows.Forms;

namespace MagusCharacterGenerator.GameSystem
{
	public struct CharacterImage
	{
		public string ImageFile { get; set; }

		public PictureBoxSizeMode SizeMode { get; set; }

		public override int GetHashCode()
		{
			return ImageFile.GetHashCode();
		}

		public void Load(PictureBox pictureBox)
		{
			try
			{
				if (ImageFile == null)
				{
					pictureBox.Image = null;
				}
				else
				{
					pictureBox.Image = Image.FromFile(ImageFile);
					pictureBox.Image.Tag = ImageFile;
					pictureBox.SizeMode = SizeMode;
				}
			}
			catch
			{
				pictureBox.Image = null;
			}
		}
	}
}
