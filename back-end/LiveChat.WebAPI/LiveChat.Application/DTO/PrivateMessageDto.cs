namespace LiveChat.Application.DTO;

public class PrivateMessageDto
{
    public Guid ReceiverId { get; set; }
    public string Message { get; set; }
}