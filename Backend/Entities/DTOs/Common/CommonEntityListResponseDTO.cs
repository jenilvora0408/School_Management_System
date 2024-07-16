namespace Entities.DTOs;

public record CommonEntityListResponseDTO
{
    public IEnumerable<GenericEntityResponseDTO>? ListOfGenders { get; set; }

    public IEnumerable<GenericEntityResponseDTO>? ListOfBloodGroups { get; set; }

    public IEnumerable<GenericEntityResponseDTO>? ListOfClasses { get; set; }

    public IEnumerable<GenericEntityResponseDTO>? ListOfMediums { get; set; }
}
