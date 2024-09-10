namespace Entities.DTOs;

public class GetUserProfileDTO
{
    public long UserId { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string Email { get; init; } = null!;

    public string? Headline { get; init; }

    public string PhoneNumber { get; init; } = null!;

    public string Address { get; init; } = null!;

    public string? City { get; init; }

    public string? Avatar { get; init; }
}
