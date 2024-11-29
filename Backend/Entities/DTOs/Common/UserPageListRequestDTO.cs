namespace Entities.DTOs;

public class UserPageListRequestDTO : PageListRequestDTO
{
    public long? UserId { get; set; }

    public string? UserName { get; set; }

    public byte? UserRole { get; set; }
}
