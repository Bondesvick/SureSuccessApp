using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SureSuccessApp.Domain.Entities;

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