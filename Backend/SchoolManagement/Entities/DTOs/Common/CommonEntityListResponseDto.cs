namespace Entities.DTOs.Common
{
    public class CommonEntityListResponseDto
    {
        public IEnumerable<GenericEntityResponseDto>? ListOfGenders { get; set; }

        public IEnumerable<GenericEntityResponseDto>? ListOfUserRoles { get; set; }

        public IEnumerable<GenericEntityResponseDto>? ListOfBloodGroups { get; set; }
    }
}