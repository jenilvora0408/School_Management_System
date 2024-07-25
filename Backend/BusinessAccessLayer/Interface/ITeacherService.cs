using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface ITeacherService
{
    Task<ViewAdmitRequestDTO> GetAdmitRequest(long id);
}
