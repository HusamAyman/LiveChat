namespace LiveChat.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public Guid ConversationId { get; set; }
    public Conversation Conversation { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Guid UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}