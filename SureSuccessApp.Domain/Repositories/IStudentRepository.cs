using SureSuccessApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SureSuccessApp.Domain.Repositories
{
    public interface IStudentRepository : IRepository
    {
        Task<IEnumerable<Student>> GetAsync();

        Task<Student> GetAsync(Guid id);

        Student Add(Student student);

        Student Update(Student student);

        Student Delete(Student student);
    }
}