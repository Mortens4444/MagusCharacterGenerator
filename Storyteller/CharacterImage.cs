namespace Storyteller;

public struct CharacterImage
{
    public string ImageFile { get; set; }

    public PictureBoxSizeMode SizeMode { get; set; }

    public override int GetHashCode()
    {
        return ImageFile.GetHashCode();
    }
}
