using M.A.G.U.S.Extensions;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions.Services;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.Models;

public abstract class ImageOwner : IHaveName, IHaveImage
{
    public virtual string Name => GetType().Name;

    //public virtual string[] Images => [$"{Name.ToImageName()}.png"];
    public virtual string[] Images
    {
        get
        {
            var safeName = (Name ?? GetType().Name).ToImageName();
            return [$"{safeName}.png"];
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string DefaultImage => Images.Length > 0 ? Images[0] : String.Empty;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual string RandomImage => Images.Length > 1 ? Images[RandomProvider.GetSecureRandomInt(0, Images.Length)] : DefaultImage;
}
