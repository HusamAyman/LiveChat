using LiveChat.Domain.Enums;

namespace LiveChat.Domain.Entities;

public class Message
{
    public Guid Id { get; set; }
    public Guid ConversationId { get; set; }
    public Conversation Conversation { get; set; }
    public Guid SenderId { get; set; }
    public string Body { get; set; }
    public MessageType Type { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsEdited { get; set; }
    public DateTime? EditedOn { get; set; }
    public Guid? EditedBy { get; set; }
    public bool IsDeleted { get; set; }
}