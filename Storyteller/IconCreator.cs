using FontAwesome.Sharp;

using Icon = System.Drawing.Icon;

namespace Storyteller
{
	public class IconCreator
	{
		public static Bitmap GetImage(IconChar iconChar, int size = 16)
		{
			return GetImage(iconChar, Color.Gray, size);
		}

        public static Bitmap GetImage(IconChar iconChar, Color color, int size = 16) => iconChar.IconCharToBitmap(size, color);

        public static Icon Get(IconChar iconChar, Color color, int size = 16)
		{
			var myBitmap = GetImage(iconChar, color, size);
			IntPtr Hicon = myBitmap.GetHicon();
			return Icon.FromHandle(Hicon);
		}
	}
}
