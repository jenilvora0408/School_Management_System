namespace Entities.DTOs;

public class PageListRequestDTO : BaseListRequestDTO
{
    public string? SearchQuery { get; set; }

    public int Filter { get; set; }
}
