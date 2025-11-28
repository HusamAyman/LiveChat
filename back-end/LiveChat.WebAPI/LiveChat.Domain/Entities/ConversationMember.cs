using LiveChat.Domain.Entities;

namespace LiveChat.Domain.Entities;

public class ConversationMember
{
    public Guid Id { get; set; }
    public Guid ConversationId { get; set; }
    public Conversation Conversation { get; set; }
    public Guid UserId { get; set; }
    public DateTime JoinedOn { get; set; }
    public bool IsMuted { get; set; }
    public bool IsArchived { get; set; }
    public bool IsDeleted { get; set; }
}