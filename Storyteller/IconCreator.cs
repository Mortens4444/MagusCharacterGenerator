using FontAwesome.Sharp;
using System;
using System.Drawing;

using Icon = System.Drawing.Icon;

namespace Storyteller
{
	class IconCreator
	{
		public static Bitmap GetImage(IconChar iconChar, int size = 16)
		{
			return GetImage(iconChar, Color.Gray, size);
		}

		public static Bitmap GetImage(IconChar iconChar, Color color, int size = 16)
		{
			return iconChar.ToBitmap(size, color);
		}

		public static Icon Get(IconChar iconChar, Color color, int size = 16)
		{
			var myBitmap = GetImage(iconChar, color, size);
			IntPtr Hicon = myBitmap.GetHicon();
			return Icon.FromHandle(Hicon);
		}
	}
}
