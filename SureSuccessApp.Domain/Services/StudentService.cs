using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SureSuccessApp.Domain.Mappers;
using SureSuccessApp.Domain.Repositories;

namespace SureSuccessApp.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentMapper _studentMapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository studentRepository, IStudentMapper studentMapper, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository;
            _studentMapper = studentMapper;
            _logger = logger;
        }

        public async Task<IEnumerable<StudentResponse>> GetStudentsAsync()
        {
            var result = await _studentRepository.GetAsync();
            return result
                .Select(x => _studentMapper.Map(x));
        }

        public async Task<StudentResponse> GetStudentAsync(GetStudentRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var entity = await _studentRepository.GetAsync(request.Id);
            return _studentMapper.Map(entity);
        }

        public async Task<StudentResponse> AddStudentAsync(AddStudentRequest request)
        {
            var item = _studentMapper.Map(request);

            var result = _studentRepository.Add(item);
            await _studentRepository.UnitOfWork.SaveChangesAsync();

            return _studentMapper.Map(result);
        }

        public async Task<StudentResponse> EditStudentAsync(EditStudentRequest request)
        {
            var existingRecord = await _studentRepository.GetAsync(request.Id);

            if (existingRecord == null) throw new ArgumentException($"Entity with {request.Id} is not present");

            var entity = _studentMapper.Map(request);
            var result = _studentRepository.Update(entity);

            await _studentRepository.UnitOfWork.SaveChangesAsync();
            return _studentMapper.Map(result);
        }

        public async Task<StudentResponse> DeleteStudentAsync(DeleteStudentRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();

            var result = await _studentRepository.GetAsync(request.Id);
            //result.IsInactive = true;

            _studentRepository.Delete(result);
            await _studentRepository.UnitOfWork.SaveChangesAsync();

            return _studentMapper.Map(result);
        }
    }
}