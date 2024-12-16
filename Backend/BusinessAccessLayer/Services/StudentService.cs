using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Interface;
using Entities.DataModels;
using Entities.DTOs;
using Entities.ExtensionMethods.MappingProfiles;
using Microsoft.AspNetCore.Http;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BusinessAccessLayer.Services;

public class StudentService(IUnitOfWork unitOfWork, ICommonService commonService) : IStudentService
{

    #region Constructor

    public readonly IUnitOfWork _unitOfWork = unitOfWork;
    public readonly ICommonService _commonService = commonService;

    #endregion Constructor

    public async Task<PageListResponseDTO<StudentsSubjectListDTO>> GetStudentsSubjectsList(UserPageListRequestDTO userPageListRequestDTO)
    {
        User? user = await _commonService.GetUserById(userPageListRequestDTO.UserId ?? 0)?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.USER_NOT_FOUND);

        Student? student = await _unitOfWork.StudentRepository.GetAsync(expression: sd => sd.StudentName == $"{user.FirstName} {user.LastName}", includes: [cls => cls.Classes]) ?? throw new CustomException(StatusCodes.Status404NotFound, MessageConstants.ErrorMessage.STUDENT_NOT_FOUND);

        int classId = student.ClassId;

        List<ClassSubject> classSubjectsList = await _unitOfWork.ClassSubjectRepository.GetAllIncludeAsync(predicate: cls => cls.ClassId == classId);

        List<int> subjectIds = classSubjectsList.Select(cs => cs.SubjectId).ToList();

        PageListRequestEntity<Subject> pageListRequestEntity = new()
        {
            PageIndex = userPageListRequestDTO.PageIndex,
            PageSize = userPageListRequestDTO.PageSize,
            Predicate = subject =>
                subjectIds.Contains(subject.Id) &&
                (string.IsNullOrEmpty(userPageListRequestDTO.SearchQuery) ||
                subject.SubjectName.ToLower().Contains(userPageListRequestDTO.SearchQuery.ToLower())),
            IncludeExpressions = [sub => sub.SubjectTeacher]
        };

        PageListResponseDTO<Subject> pageListResponse = await _unitOfWork.SubjectRepository.GetAllAsync(pageListRequestEntity);

        List<StudentsSubjectListDTO> studentsSubjectsListDTO = SubjectMappingProfile.ToGetSubjectsListForStudents(pageListResponse.Records, classId, student.Classes.ClassName); 

        return new PageListResponseDTO<StudentsSubjectListDTO>(
            pageListResponse.PageIndex,
            pageListResponse.PageSize,
            pageListResponse.TotalRecords,
            studentsSubjectsListDTO
        );
    }
}
