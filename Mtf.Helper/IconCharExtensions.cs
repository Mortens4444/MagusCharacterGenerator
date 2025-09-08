using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Linq;

namespace Mtf.Helper
{
    public static class IconCharExtensions
    {
        public static Bitmap IconCharToBitmap(this IconChar iconChar, int size, Color color)
        {
            // próbáljuk megtalálni a FontAwesome font családot, ha nincs, fallback a rendszerre
            FontFamily fam = null;
            try
            {
                var candidates = new[]
                {
            "Font Awesome 6 Free",
            "Font Awesome 6 Pro",
            "Font Awesome 5 Free",
            "Font Awesome 5 Pro",
            "FontAwesome", // régebbi elnevezések
        };

                fam = FontFamily.Families.FirstOrDefault(f => candidates.Any(c =>
                    string.Equals(f.Name, c, StringComparison.OrdinalIgnoreCase)));

                if (fam == null) fam = SystemFonts.DefaultFont.FontFamily;
            }
            catch
            {
                fam = SystemFonts.DefaultFont.FontFamily;
            }

            // az új API szerint: FormsIconHelper.ToBitmap<int>(FontFamily, int glyph, int size, Color? color, double ?, FlipOrientation)
            // a '?' helyére 0.0 (rotáció vagy scale paraméter), FlipOrientation.Normal
            var glyph = (int)iconChar;
            var bmp = FormsIconHelper.ToBitmap<int>(fam, glyph, size, color, 0.0, FlipOrientation.Normal);
            return bmp;
        }
    }
}
