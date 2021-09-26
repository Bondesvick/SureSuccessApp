using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using SureSuccessApp.Domain.Entities;

namespace SureSuccessApp.Domain.Mappers
{
    public interface IStudentMapper
    {
        Student Map(AddStudentRequest request);

        Student Map(EditStudentRequest request);

        StudentResponse Map(Student request);
    }
}