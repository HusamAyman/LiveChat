namespace LiveChat.Domain.Entities;

public class Attachment
{
    public Guid Id { get; set; }
    public Guid MessageId { get; set; }
    public Message Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public string FileUrl { get; set; }
    public double FileSize { get; set; }
    public string MimeType { get; set; }
    public string ThumbnailUrl { get; set; }
}