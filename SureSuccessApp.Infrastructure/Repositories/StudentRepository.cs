using Microsoft.EntityFrameworkCore;
using SureSuccessApp.Domain.Entities;
using SureSuccessApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SureSuccessApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Student Add(Student student)
        {
            return _context.Students.Add(student).Entity;
        }

        public Student Delete(Student student)
        {
            _context.Students.Remove(student);

            return student;
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student> GetAsync(Guid id)
        {
            var student = await _context.Students
                .AsNoTracking().FirstOrDefaultAsync();

            if (student == null) return null;

            _context.Entry(student).State = EntityState.Detached;
            return student;
        }

        public Student Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            return student;
        }
    }
}