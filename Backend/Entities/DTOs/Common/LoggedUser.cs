namespace Entities.DTOs;

public class LoggedUser
{
    public long UserId { get; set; }

    public int Role { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
