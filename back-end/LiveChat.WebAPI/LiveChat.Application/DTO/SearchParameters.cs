namespace LiveChat.Application.DTO;

public class SearchParameters
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }

    public SearchParameters()
    {
        PageNumber = 1;
        PageSize = 10;
    }
}