using System.Text.Json.Serialization;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

namespace Lagrange.OneBot.Message.Entity;

[Serializable]
public partial class MarketFaceSegment
{
    public MarketFaceSegment() { }
    public MarketFaceSegment(string faceName, string faceId, string faceKey, int imageHeight, int imageWidth, int tabId)
    {
        FaceName = faceName;
        FaceId = faceId;
        FaceKey = faceKey;
        ImageHeight = imageHeight;
        ImageWidth = imageWidth;
        TabId = tabId;
    }

    [JsonPropertyName("faceName")] [CQProperty] public string FaceName { get; set; } = string.Empty;

    [JsonPropertyName("faceId")] [CQProperty] public string FaceId { get; set; } = string.Empty;

    [JsonPropertyName("key")] [CQProperty] public string? FaceKey { get; set; }

    [JsonPropertyName("imageHeight")] [CQProperty] public int? ImageHeight { get; set; }

    [JsonPropertyName("imageWidth")] [CQProperty] public int? ImageWidth { get; set; }

    [JsonPropertyName("tabId")] [CQProperty] public int? TabId { get; set; }
}

[SegmentSubscriber(typeof(MarketFaceEntity), "mface")]
public partial class MarketFaceSegment : SegmentBase
{
    public override void Build(MessageBuilder builder, SegmentBase segment) { }

    public override SegmentBase FromEntity(MessageChain chain, IMessageEntity entity)
    {
        if (entity is not MarketFaceEntity marketFaceEntity) throw new ArgumentException("Invalid entity type.");

        return new MarketFaceSegment(
            marketFaceEntity.FaceName,
            marketFaceEntity.FaceId ?? "",
            marketFaceEntity.Key ?? "",
            marketFaceEntity.ImageHeight ?? -1,
            marketFaceEntity.ImageWidth ?? -1,
            marketFaceEntity.TabId ?? -1
        );
    }
}