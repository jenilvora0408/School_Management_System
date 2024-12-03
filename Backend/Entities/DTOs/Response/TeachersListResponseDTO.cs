namespace Entities.DTOs;

public class TeachersListResponseDTO
{
    public long UserId { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public bool IsAssigned { get; set; }

    public int? AssignedClassId { get; set; }
}
