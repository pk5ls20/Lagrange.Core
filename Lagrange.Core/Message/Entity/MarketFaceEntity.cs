namespace Lagrange.Core.Message.Entity;

using Lagrange.Core.Internal.Packets.Message.Element;
using Lagrange.Core.Internal.Packets.Message.Element.Implementation;

[MessageElement(typeof(MarketFace))]
public class MarketFaceEntity : IMessageEntity
{
    public string FaceName { get; set;} = string.Empty;

    public string? FaceId { get; set;}

    public string? Key { get; set;}

    public int? ImageHeight { get; set;}

    public int? ImageWidth { get; set;}

    public int? TabId { get; set;}

    public MarketFaceEntity() {}
    
    private MarketFaceEntity(string faceName, string faceId, string faceKey, int imageHeight, int imageWidth, int tabId)
    {
        FaceName = faceName;
        FaceId = faceId;
        Key = faceKey;
        ImageHeight = imageHeight;
        ImageWidth = imageWidth;
        TabId = tabId;
    }

    // TODO: complete it until I want to use it
    IEnumerable<Elem> IMessageEntity.PackElement()
    {
        return new List<Elem>();
    }

    IMessageEntity? IMessageEntity.UnpackElement(Elem elems)
    {
        if (elems.MarketFace is { } marketFace)
        {
            return new MarketFaceEntity(
                faceName: System.Text.Encoding.UTF8.GetString(marketFace.FaceName),
                faceId: string.Concat(marketFace.FaceId.Select(b => b.ToString("x2"))),
                faceKey: string.Concat(marketFace.Key.Select(b => (char)b)),
                imageHeight: marketFace.ImageHeight,
                imageWidth: marketFace.ImageWidth,
                tabId: marketFace.TabId
            );
        }

        return null;
    }

    public string ToPreviewString() => $"[{nameof(MarketFaceEntity)}: {FaceName}]";
}