using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SureSuccessApp.Domain.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponse>> GetStudentsAsync();

        Task<StudentResponse> GetStudentAsync(GetStudentRequest request);

        Task<StudentResponse> AddStudentAsync(AddStudentRequest request);

        Task<StudentResponse> EditStudentAsync(EditStudentRequest request);

        Task<StudentResponse> DeleteStudentAsync(DeleteStudentRequest request);
    }
}