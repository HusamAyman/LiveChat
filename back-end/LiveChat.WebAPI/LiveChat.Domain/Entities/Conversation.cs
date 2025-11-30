using LiveChat.Domain.Enums;

namespace LiveChat.Domain.Entities;

public class Conversation
{
    public Guid Id { get; set; }
    public ConversationType Type { get; set; }
    public string? Name { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ConversationMember> Members { get; set; }
    public ICollection<Message> Messages { get; set; }
    public Group? Group { get; set; }
}