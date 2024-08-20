using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IPrincipalService
{
    Task UpsertClasses(ClassRequestDTO classRequestDTO, CancellationToken cancellationToken);
}
