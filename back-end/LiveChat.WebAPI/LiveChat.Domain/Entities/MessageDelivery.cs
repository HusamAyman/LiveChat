namespace LiveChat.Domain.Entities;

public class MessageDelivery
{
    public Guid Id { get; set; }
    public Guid MessageId { get; set; }
    public Message Message { get; set; }
    public Guid ReceiverId { get; set; }
    public bool IsDelivered { get; set; }
    public DateTime? DeliveredOn { get; set; }
    public bool IsSeen { get; set; }
    public DateTime? SeenOn { get; set; }
}