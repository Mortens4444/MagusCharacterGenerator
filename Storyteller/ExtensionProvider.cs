namespace Storyteller;

static class ExtensionProvider
{
	public static string[] ImagesFilter => new[] { "*.png", "*.bmp", "*.dib", "*.jpg", "*.jepg", "*.jpe", "*.jfif", "*.gif", "*.tga", "*.dds", "*.tif", "*.tiff" };

	public static string[] AudioFilter => new[] { "*.wav", "*.mp3" };

	public static string[] VideoFilter => new[] { "*.avi", "*.mov", "*.mpg", "*.mpeg" };

	public static string CharacterSheetExtension = ".json";
}
